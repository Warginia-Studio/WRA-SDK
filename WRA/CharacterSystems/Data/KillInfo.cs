using UnityEngine;

namespace WRA.CharacterSystems.Data
{
    public class KillInfo : InfoBase
    {
        public bool WillBeDead=true;
        
        public KillInfo(Transform caster, Transform target) : base(caster, target)
        {
            
        }
    }
}
