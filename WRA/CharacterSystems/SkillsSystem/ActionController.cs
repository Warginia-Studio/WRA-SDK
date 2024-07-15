using System.Collections.Generic;
using UnityEngine;

namespace WRA.CharacterSystems.SkillsSystem
{
    public class ActionController : CharacterSystemBase
    {
        private List<ActionBase> activeActions = new List<ActionBase>();
        private List<Coroutine> coroutines = new List<Coroutine>();

        private CharacterData characterData;

        public void BeginAction(ActionBase actionBase)
        {
            var cor = StartCoroutine(actionBase.ActionEngine(characterData));
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
