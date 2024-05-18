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
        public static PoolBase<TObject> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PoolBase<TObject>();
                }

                return instance;
            }
        }
        
        [Inject] public PoolObjectFactory poolObjectFactory;

        private static PoolBase<TObject> instance;
        protected TObject prefab;
        
        protected List<TObject> pool = new List<TObject>();

        public PoolBase()
        {
            LoadPrefab();       
        }
        
        public void FillPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                InitObject();
            }
        }

        public void FreePool()
        {
            
        }

        public void KillAll()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                pool[i].Kill();
            }
        }
        
        private string prefabName;

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

        protected virtual void LoadPrefab()
        {
            prefab = Resources.Load<TObject>($"PooledObjects/{typeof(TObject).Name}");
        }
        
        private void InitObject()
        {
            // TObject obj = Object.Instantiate(prefab);
            TObject obj = poolObjectFactory.Create(prefabName) as TObject;
            obj.gameObject.name += "_Pooled_ID=" + pool.Count;
            obj.OnInit();
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
}
