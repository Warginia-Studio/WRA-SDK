using System.Collections;
using UnityEngine;

namespace WRA.CharacterSystems.SkillsSystem
{
    public abstract class ActionBase : ScriptableObject
    {
        public string ActionName;
        [TextArea] public string DefaultDescription;
        public Sprite ActionSprite;
    
        protected ActionControler ActionControler;
    
        public abstract string GetDescription(object owner);
    
        public abstract IEnumerator ActionEngine(object actionBase);
        
    }
}
