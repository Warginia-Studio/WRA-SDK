using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "thief01/WRA-SDK/Behaviours/Effects/Base Effect")]
public abstract class EffectBehaviourBase : ScriptableObject, IResourceEffect
{

    public abstract void PlayEffect(Transform target);
}
