using System.Collections;
using System.Collections.Generic;
using Character;
using DependentObjects.ScriptableObjects;
using UnityEngine;

public class Skill : ContainerItem, IUseableItem
{
    [SerializeField] private ActionBase actionBase;
    
    public ActionBase GetActionReference()
    {
        return actionBase;
    }
}
