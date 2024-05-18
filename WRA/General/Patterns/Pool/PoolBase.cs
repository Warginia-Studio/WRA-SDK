using System.Collections.Generic;
using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using WRA.Zenject;
using Zenject;

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

        public TObject SpawnObject<TObject>() where TObject : PoolObjectBase
        {
            return SpawnObject() as TObject;
        }

        public virtual TObject SpawnObject()
        {
            TObject obj = null;
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].gameObject.activeSelf)
                {
                    obj = pool[i];
                    break;
                }
            }

            if (obj == null)
            {
                WraDiagnostics.LogWarning($"Pool is empty, creating new object. Type: {typeof(TObject).Name}");
                InitObject();
                obj = pool[^1];
            }

            obj.OnSpawn();
            return obj;
        }
        
        private void InitObject()
        {
            TObject obj = poolObjectFactory.Create(prefabName) as TObject;
            obj.gameObject.name += "_Pooled_ID=" + pool.Count;
            obj.OnInit();
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
}
