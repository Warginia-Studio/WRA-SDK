using UnityEngine;

namespace WRA.CharacterSystems
{
    public class CharacterSystemBase : MonoBehaviour
    {
        public CharacterSystemsProvider CharacterSystemsProvider { get; private set; }

        public void InitCharacterSystemsProvider(CharacterSystemsProvider characterSystemsProvider)
        {
            CharacterSystemsProvider = characterSystemsProvider;
        }
    }
}
