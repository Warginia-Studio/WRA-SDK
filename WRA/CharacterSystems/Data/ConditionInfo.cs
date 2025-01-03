using UnityEngine;

namespace WRA.CharacterSystems.Data
{
    public class ConditionInfo : ResourcesChangedBase
    {
        public ConditionInfo(Transform caster, Transform target, float modifiedValue) : base(caster, target, modifiedValue)
        {
        }
    }
}