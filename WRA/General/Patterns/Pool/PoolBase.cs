using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using WRA.Zenject;
using WRA.Zenject.Pool;
using Zenject;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.General.Patterns.Pool
{
    public class PoolBase<TObject> : IPool where TObject : PoolObjectBase
    {
        [Inject] public PoolObjectFactory poolObjectFactory;
        
        public UnityEvent<PoolObjectBase> OnCreateEvent = new UnityEvent<PoolObjectBase>();
        
        protected List<TObject> pool = new List<TObject>();
        
        public void FreePool()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                GameObject.Destroy(pool[i].gameObject);
            }
            pool.Clear();
        }

        public void KillAll()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                pool[i].Kill();
            }
        }
        
        public PoolObjectBase SpawnObject(int id = 0)
        {
            TObject obj = null;
            obj = FindAvailableObject(id);
            

            if (obj == null)
            {
                Diagnostics.Log($"Pool is empty, creating new object. Type: {typeof(TObject).Name}", LogType.warning);
                obj = InitObject(id);
                OnCreateEvent?.Invoke(obj);
            }

            obj.Spawn();
            return obj;
        }
        
        private TObject FindAvailableObject(int id)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].gameObject.activeSelf && pool[i].VariantId == id)
                    return pool[i];
                
            }
            return null;
        }
        
        
        private TObject InitObject(int id)
        {
            TObject obj = poolObjectFactory.Create<TObject>(id);
            obj.gameObject.name += "_Pooled_ID=" + pool.Count;
            obj.OnInit();
            obj.SetActive(false);
            pool.Add(obj);
            
            return obj;
        }
    }
}
