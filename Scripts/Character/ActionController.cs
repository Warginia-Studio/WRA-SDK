using System.Collections.Generic;
using DependentObjects.ScriptableObjects;
using UnityEngine;

namespace Character
{
    public class ActionController : MonoBehaviour
    {
        private List<ActionBase> activeActions = new List<ActionBase>();
    
        public void BeginAction(ActionBase actionBase)
        {
            StartCoroutine(actionBase.ActionEngine(this));
        }

        public void BreakAction(ActionBase actionBase)
        {
        
        }

        public void BreakAction(string actionName)
        {
        
        }
    }
}
