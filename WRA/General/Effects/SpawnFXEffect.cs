using UnityEngine;

namespace WRA.General.Effects
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Effects/Spawn FX")]
    public class SpawnFXEffect : EffectBehaviourBase
    {
        [SerializeField] private GameObject FXPrefab;
        [SerializeField] private float destroyTime;
        public override void PlayEffect(Vector3 target)
        {
            var go = Instantiate(FXPrefab);
            go.transform.position = target;
            Destroy(go, destroyTime);
        }
    }
}
