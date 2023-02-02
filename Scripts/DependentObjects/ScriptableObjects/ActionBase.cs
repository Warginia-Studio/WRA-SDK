using System.Collections;
using Character;
using UnityEngine;

namespace DependentObjects.ScriptableObjects
{
    public abstract class ActionBase : ScriptableObject
    {
        public string ActionName;
    
        protected ActionController ActionController;
    
        public abstract string GetDescription(ActionController owner);
    
        public abstract IEnumerator ActionEngine(ActionController owner);
    }
}
