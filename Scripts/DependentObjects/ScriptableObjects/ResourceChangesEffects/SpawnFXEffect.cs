using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "thief01/WRA-SDK/Effects/Spawn FX")]
public class SpawnFXEffect : EffectBehaviourBase
{
    [SerializeField] private GameObject FXPrefab;
    [SerializeField] private float destroyTime;
    public override void PlayEffect(Transform target)
    {
        var go = Instantiate(FXPrefab);
        go.transform.position = target.position;
        Destroy(go, destroyTime);
    }
}
