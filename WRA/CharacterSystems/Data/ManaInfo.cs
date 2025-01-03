using UnityEngine;

namespace WRA.CharacterSystems.Data
{
    public class ManaInfo : ResourcesChangedBase
    {
        public ManaInfo(Transform caster, Transform target, float modifiedValue) : base(caster, target, modifiedValue)
        {
        }
    }
}