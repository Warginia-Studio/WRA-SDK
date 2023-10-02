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
    protected CharacterObject characterObject;
    public void SetCharacterObject(CharacterObject characterObject)
    {
        this.characterObject = characterObject;
    }
}
