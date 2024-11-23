using System.Collections.Generic;
using UnityEngine;

namespace WRA_SDK.WRA.General.ZenjectInstallers
{
    public class ManagersHolder : MonoBehaviour
    {
        [SerializeField] private List<ManagerBase> managers;
        
        public T GetManager<T>() where T : ManagerBase
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
