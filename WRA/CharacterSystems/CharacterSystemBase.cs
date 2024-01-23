using UnityEngine;

namespace WRA.CharacterSystems
{
    [RequireComponent(typeof(CharacterObject))]
    public class CharacterSystemBase : MonoBehaviour
    {
        public CharacterObject CharacterObject
        {
            get
            {
                if (characterObject == null)
                {
                    characterObject = GetComponent<CharacterObject>();
                }

                return characterObject;
            }
        }
        private CharacterObject characterObject;
        public void SetCharacterObject(CharacterObject characterObject)
        {
            this.characterObject = characterObject;
            OnInitDone();
        }
    
        public T GetCharacterSystem<T>() where T : CharacterSystemBase
        {
            return characterObject.GetCharacterSystem<T>();
        }
        
        public virtual void OnInitDone() {}
    }
}
