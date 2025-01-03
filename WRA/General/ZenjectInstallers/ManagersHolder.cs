using System.Collections.Generic;
using UnityEngine;

namespace WRA.General.ZenjectInstallers
{
    public class ManagersHolder : MonoBehaviour
    {
        [SerializeField] private List<CustomManagerBase> managers;
        
        public T GetManager<T>() where T : CustomManagerBase
        {
            foreach (var manager in managers)
            {
                if (manager is T)
                {
                    return (T)manager;
                }
            }

            return null;
        }
    }
}
