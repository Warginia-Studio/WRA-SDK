using System.Collections;
using UnityEngine;
using WRACore.Character;

namespace WRACore.DependentObjects.ScriptableObjects
{
    public abstract class ActionBase : ScriptableObject
    {
        public string ActionName;
    
        protected ActionController ActionController;
    
        public abstract string GetDescription(ActionController owner);
    
        public abstract IEnumerator ActionEngine(ActionController owner);
    }
}
