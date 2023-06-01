using System.Collections;
using Character;
using DependentObjects.Classes;
using UnityEngine;

namespace DependentObjects.ScriptableObjects
{
    public abstract class ActionBase : ScriptableObject
    {
        public string ActionName;
        public string DefaultDescription;
        [SerializeField]
        public Sprite ActionSprite;
    
        protected ActionController ActionController;
    
        public abstract string GetDescription(ActionData owner);
    
        public abstract IEnumerator ActionEngine(ActionData owner);
        
    }
}
