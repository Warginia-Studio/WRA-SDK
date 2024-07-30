using System.Collections.Generic;
using WRA.General.Patterns.Pool;
using WRA.Utility.Diagnostics.Logs;
using Zenject;

namespace WRA.Zenject.Pool
{
    public class PoolObjectFactory : PlaceholderFactory<string, PoolObjectBase>
    {
        private readonly DiContainer container;
        private readonly List<PoolObjectBase> poolObjects;
    
        public PoolObjectFactory(DiContainer container, List<PoolObjectBase> poolObjects)
        {
            this.container = container;
            this.poolObjects = poolObjects;
        }
    
        public PoolObjectBase Create(int id)
        {
            foreach (var poolObject in poolObjects)
            {
                if (poolObject.VariantId != id)
                    continue;

                var pool = container.InstantiatePrefab(poolObject.gameObject).GetComponent<PoolObjectBase>();
                return pool;

            }

            return null;
        }
        
        public TObject Create<TObject>(int id) where TObject : PoolObjectBase
        {
            foreach (var poolObject in poolObjects)
            {
                if (poolObject is not TObject || poolObject.VariantId != id)
                    continue;
                var pool = container.InstantiatePrefab(poolObject.gameObject).GetComponent<TObject>();
                return pool;
            }
            
            Diagnostics.Log($"PoolObjectFactory: PoolObject not found. ID: {id} Type: {typeof(TObject).Name}", LogType.failed);

            return null;
        }
    }
}
