using System.Collections.Generic;
using UnityEngine;
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
        
        private string prefabName;
        
        protected List<TObject> pool = new List<TObject>();
        
        public void FillPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                InitObject();
            }
        }

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
        
        public void SetPrefab(string name)
        {
            prefabName = name;
        }
        
        public TObject SpawnObjectAsType()
        {
            return (TObject)SpawnObject();
        }
        
        public PoolObjectBase SpawnObject()
        {
            TObject obj = null;
            obj = FindAvailableObject();
            

            if (obj == null)
            {
                Diagnostics.Log($"Pool is empty, creating new object. Type: {typeof(TObject).Name}", LogType.warning);
                obj = InitObject();
            }

            obj.OnSpawn();
            return obj;
        }
        
        private TObject FindAvailableObject()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].gameObject.activeSelf)
                    return pool[i];
                
            }
            return null;
        }
        
        
        private TObject InitObject()
        {
            TObject obj = poolObjectFactory.Create<TObject>(prefabName);
            obj.gameObject.name += "_Pooled_ID=" + pool.Count;
            obj.OnInit();
            obj.SetActive(false);
            pool.Add(obj);
            
            return obj;
        }
    }
}
