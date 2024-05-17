using System.Collections.Generic;
using WRA.General.Patterns.Pool;
using Zenject;

namespace WRA.Zenject
{
    public class PoolObjectFactory : IFactory<string, PoolObjectBase>
    {
        private readonly DiContainer container;
        private readonly List<PoolObjectBase> poolObjects;
    
        public PoolObjectFactory(DiContainer container, List<PoolObjectBase> poolObjects)
        {
            this.container = container;
            this.poolObjects = poolObjects;
        }
    
        public PoolObjectBase Create(string param)
        {
            foreach (var poolObject in poolObjects)
            {
                if (poolObject.name == param)
                {
                    var pool = container.InstantiatePrefab(poolObject.gameObject).GetComponent<PoolObjectBase>();
                    return pool;
                }
            }
            return null;
        }
    }
}
