using System.Collections;
using System.Collections.Generic;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;

public class ArmamentSlot : ContainerSlot<ArmableItem>
{
    public ArmamentSlot(ArmableItem containerItem, Vector2Int position) : base(containerItem)
    {
    }
}
