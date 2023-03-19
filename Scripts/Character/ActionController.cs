using System.Collections.Generic;
using DependentObjects.ScriptableObjects;
using UnityEngine;

namespace Character
{
    public class ActionController : MonoBehaviour
    {
        private List<ActionBase> activeActions = new List<ActionBase>();
        private List<Coroutine> coroutines = new List<Coroutine>();

        public void BeginAction(ActionBase actionBase)
        {
            var cor = StartCoroutine(actionBase.ActionEngine(this));
            activeActions.Add(actionBase);
            coroutines.Add(cor);
        }

        public void BreakAction(ActionBase actionBase)
        {
        
        }

        public void BreakAction(string actionName)
        {
        
        }
    }
}
