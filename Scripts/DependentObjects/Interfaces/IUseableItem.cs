using System.Collections;
using System.Collections.Generic;
using Character;
using DependentObjects.ScriptableObjects;
using UnityEngine;

public interface IUseableItem
{
    ActionBase GetActionReference();
}
