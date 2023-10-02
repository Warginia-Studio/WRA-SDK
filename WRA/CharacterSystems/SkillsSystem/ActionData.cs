using UnityEngine;

namespace WRA.CharacterSystems.SkillsSystem
{
    [System.Serializable]
    public class ActionData
    {
        public CharacterObject CharacterObject { get; set; }

        public ActionData(CharacterObject characterObject)
        {
            CharacterObject = characterObject;
        }
    
    }
}
