using UnityEngine;

namespace WRA.CharacterSystems.StatisticsSystem.ResourcesInfos
{
    public class KillInfo : InfoBase
    {
        public bool WillBeDead=true;
        
        public CharacterSystemBase Killer;
        public CharacterSystemBase KilledUnit;

        public KillInfo(CharacterSystemBase owner, CharacterSystemBase killer, CharacterSystemBase killedUnit)
        {
            Owner = owner;
            Killer = killer;
            KilledUnit = killedUnit;
        }
    }
}
