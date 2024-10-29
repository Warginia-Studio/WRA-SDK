using UnityEngine;

namespace WRA.CharacterSystems.StatisticsSystem.ResourcesInfos
{
    public class InfoBase
    {
        public Transform Caster;
        
        public Transform Target;
        
        public InfoBase(Transform caster, Transform target)
        {
            Caster = caster;
            Target = target;
        }
    }
}
