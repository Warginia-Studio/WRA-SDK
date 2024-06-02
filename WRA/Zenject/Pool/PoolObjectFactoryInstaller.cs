using System.Collections.Generic;
using UnityEngine;
using WRA.General.Patterns.Pool;
using Zenject;

namespace WRA.Zenject.Pool
{
    [CreateAssetMenu(fileName = "PoolObjectFactoryInstaller", menuName = "thief01/WRA-SDK/Installers/PoolObjectFactoryInstaller")]
    public class PoolObjectFactoryInstaller : ScriptableObjectInstaller<PoolObjectFactoryInstaller>
    {
        [SerializeField] private string[] dictionaryPaths = new []{ "SDK/Pool" };
    
        public override void InstallBindings()
        {
            LoadPrefabs();
            Container.BindFactory<string, PoolObjectBase, PoolObjectFactory>().FromFactory<PoolObjectFactory>();
        }
    
        private void LoadPrefabs()
        {
            var prefabs = new List<PoolObjectBase>();
        
            foreach (var path in dictionaryPaths)
            {
                var loadedPrefabs = Resources.LoadAll<PoolObjectBase>(path);
                if (loadedPrefabs != null)
                {
                    prefabs.AddRange(loadedPrefabs);
                }
            }


            Container.Bind<List<PoolObjectBase>>().FromInstance(prefabs);
        }
    }
}
