using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystemBase : MonoBehaviour
{
    public CharacterSystemsProvider CharacterSystemsProvider { get; private set; }

    public void InitCharacterSystemsProvider(CharacterSystemsProvider characterSystemsProvider)
    {
        CharacterSystemsProvider = characterSystemsProvider;
    }
}
