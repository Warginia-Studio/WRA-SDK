using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    private List<CharacterSystemBase> characterSystemBases;

    private bool registeredSystems = false;
    private void Awake()
    {
       RegisterAllSystems();
    }

    public T GetCharacterSystem<T>() where T : CharacterSystemBase
    {
        if(!registeredSystems)
            RegisterAllSystems();
        return characterSystemBases.Find(ctg => ctg is T) as T;
    }

    private void RegisterAllSystems()
    {
        if (characterSystemBases != null)
            return;
        registeredSystems = true;
        characterSystemBases = GetComponents<CharacterSystemBase>().ToList();
        characterSystemBases.ForEach(ctg=> ctg.SetCharacterObject(this));
    }
}
