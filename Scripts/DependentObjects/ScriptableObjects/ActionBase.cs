using System.Collections;
using Character;
using DependentObjects.Classes;
using Unity.VisualScripting;
using UnityEngine;

namespace DependentObjects.ScriptableObjects
{
    public abstract class ActionBase : ScriptableObject
    {
        public string ActionName;
        [TextArea] public string DefaultDescription;
        public Sprite ActionSprite;
    
        protected ActionController ActionController;
    
        public abstract string GetDescription(ActionData owner);
    
        public abstract IEnumerator ActionEngine(ActionData actionBase);
        
    }
}
