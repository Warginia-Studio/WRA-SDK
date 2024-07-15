using UnityEngine;

namespace WRA.CharacterSystems.SkillsSystem
{
    [System.Serializable]
    public class CharacterData
    {
        public CharacterObject CharacterObject { get; set; }

        public CharacterData(CharacterObject characterObject)
        {
            CharacterObject = characterObject;
        }
    }
}
