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
    
        public PoolObjectBase Create(string name)
        {
            foreach (var poolObject in poolObjects)
            {
                if (poolObject.name != name)
                    continue;

                var pool = container.InstantiatePrefab(poolObject.gameObject).GetComponent<PoolObjectBase>();
                return pool;

            }

            return null;
        }
        
        public TObject Create<TObject>(string name) where TObject : PoolObjectBase
        {
            foreach (var poolObject in poolObjects)
            {
                if (poolObject is not TObject)
                    continue;
                var pool = container.InstantiatePrefab(poolObject.gameObject).GetComponent<TObject>();
                return pool;
            }
            
            WraDiagnostics.LogError("PoolObjectFactory: Create: PoolObject not found. Name: " + name + " Type: " + typeof(TObject).Name);

            return null;
        }
    }
}
