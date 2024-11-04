using System.Collections;
using UnityEngine;

namespace WRA.CharacterSystems.SkillsSystem
{
    public abstract class ActionBase : ScriptableObject
    {
        public string ActionName;
        [TextArea] public string DefaultDescription;
        public Sprite ActionSprite;
    
        protected ActionController ActionController;

        public void BeginAction<T>(T actionBaseData) where T : CharacterData
        {
            actionBaseData.CharacterObject.StartCoroutine(ActionEngine(actionBaseData));
        }
    
        public abstract string GetDescription<T>(T owner) where T : CharacterData;
    
        public abstract IEnumerator ActionEngine<T>(T actionBase) where T : CharacterData;
        
    }
}
