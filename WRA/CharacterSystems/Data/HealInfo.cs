using UnityEngine;

namespace WRA.CharacterSystems.StatisticsSystem.ResourcesInfos
{
    public class HealInfo : ResourcesChangedBase
    {
        public HealInfo(Transform caster, Transform target, float modifiedValue, float modifiedValuePercent) : base(caster, target, modifiedValue, modifiedValuePercent)
        {
        }
    }
}