using System.Collections.Generic;
using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;

namespace WRA.General.Patterns.Pool
{
    public class PoolBase<TObject> where TObject : PoolObjectBase 
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

        private static PoolBase<TObject> instance;
        protected TObject prefab;
        
        protected List<TObject> pool = new List<TObject>();

        protected PoolBase()
        {
            LoadPrefab();       
        }

        public void FillPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                pool.Add(Object.Instantiate(prefab));
                pool[i].gameObject.name += "_Pooled_ID=" + i;
                pool[i].OnInit();
                pool[i].SetActive(false);
            }
        }
        
        public void KillAll()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                pool[i].Kill();
            }
        }

        public virtual TObject GetObject()
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
                obj = Object.Instantiate(prefab);
                pool.Add(obj);
            }

            obj.OnSpawn();
            return obj;
        }

        protected virtual void LoadPrefab()
        {
            prefab = Resources.Load<TObject>($"PooledObjects/{typeof(TObject).Name}");
        }
    }
}
