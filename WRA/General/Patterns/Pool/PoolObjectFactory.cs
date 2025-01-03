using System.Collections.Generic;
using WRA.Utility.Diagnostics.Logs;
using Zenject;

namespace WRA.General.Patterns.Pool
{
    public class PoolObjectFactory : PlaceholderFactory<string, PoolObject>
    {
        private readonly DiContainer container;
        private readonly List<PoolObject> poolObjects;
    
        public PoolObjectFactory(DiContainer container, List<PoolObject> poolObjects)
        {
            this.container = container;
            this.poolObjects = poolObjects;
        }
    
        public PoolObject Create(int id)
        {
            foreach (var poolObject in poolObjects)
            {
                if (poolObject.VariantId != id)
                    continue;

                var pool = container.InstantiatePrefab(poolObject.gameObject).GetComponent<PoolObject>();
                return pool;
            }

            return null;
        }
        
        public TObject Create<TObject>(int id) where TObject : PoolObject
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
