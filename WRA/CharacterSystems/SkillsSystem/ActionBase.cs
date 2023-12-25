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

        public void BeginAction<T>(T actionBaseData) where T : ActionData
        {
            actionBaseData.CharacterObject.StartCoroutine(ActionEngine(actionBaseData));
        }
    
        public abstract string GetDescription<T>(T owner) where T : ActionData;
    
        public abstract IEnumerator ActionEngine<T>(T actionBase) where T : ActionData;
        
    }
}
