using DependentObjects.Interfaces;
using UnityEngine;

namespace DependentObjects.ScriptableObjects.Managment
{
    public class Skill : ContainerItem, IUseableItem
    {
        [SerializeField] private ActionBase actionBase;
    
        public ActionBase GetActionReference()
        {
            return actionBase;
        }
    }
}
