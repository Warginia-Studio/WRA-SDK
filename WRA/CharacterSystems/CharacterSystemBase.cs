using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.CharacterSystems.InteractionsSystem;
using WRA.CharacterSystems.SkillsSystem;
using WRA.CharacterSystems.StatisticsSystem;
using WRA.Utility.Diagnostics;

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
    }
    
    public T GetCharacterSystem<T>() where T : CharacterSystemBase
    {
        return characterObject.GetCharacterSystem<T>();
    }
}
