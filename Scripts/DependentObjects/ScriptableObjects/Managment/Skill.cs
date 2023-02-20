using System.Collections;
using System.Collections.Generic;
using Character;
using DependentObjects.ScriptableObjects;
using UnityEngine;

public class Skill : ContainerItem, IUseable
{
    [SerializeField] private ActionBase actionBase;
    
    public void Use(ActionController user)
    {
        user.BeginAction(actionBase);
    }

    public float GetCooldown(ActionController user)
    {
        return 0;
    }
}
