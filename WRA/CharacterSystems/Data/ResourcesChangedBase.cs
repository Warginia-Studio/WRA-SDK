using UnityEngine;

namespace WRA.CharacterSystems.Data
{
    public class ResourcesChangedBase : InfoBase
    {
        public float ModifiedValue;
        public float ModifiedValuePercent;

        public ResourcesChangedBase(Transform caster, Transform target, float modifiedValue = 0,
            float modifiedValuePercent = 0) : base(caster, target)
        {
            ModifiedValue = modifiedValue;
            ModifiedValuePercent = modifiedValuePercent;
        }
    }
}