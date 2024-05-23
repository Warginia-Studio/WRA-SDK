using UnityEngine;

namespace WRA.CharacterSystems.StatisticsSystem.ResourcesInfos
{
    public class KillInfo : InfoBase
    {
        public bool WillBeDead=true;

        public KillInfo(CharacterSystemBase owner)
        {
            Owner = owner;
        }
    }
}
