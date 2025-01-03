using UnityEngine;

namespace WRA.CharacterSystems.Data
{
    public class DamageInfo : ResourcesChangedBase
    {
        public DamageInfo(Transform caster, Transform target, float modifiedValue = 0, float modifiedValuePercent = 0) : base(caster, target, modifiedValue, modifiedValuePercent)
        {
            
        }
    }
}