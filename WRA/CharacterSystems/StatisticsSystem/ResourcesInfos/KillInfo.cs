using UnityEngine;

namespace WRA.CharacterSystems.StatisticsSystem.ResourcesInfos
{
    public class KillInfo
    {
        public bool WillBeDead=true;
        public CharacterSystemBase Killer;
    
        public KillInfo(CharacterSystemBase killer)
        {
            Killer = killer;
        }
    }
}
