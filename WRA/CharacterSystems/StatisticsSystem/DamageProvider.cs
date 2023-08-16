using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA.CharacterSystems.StatisticsSystem
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Providers/Damage Provider" , fileName = "Damage Provider")]
    public class DamageProvider : ScriptableObject
    {
        public virtual float CalculateDamage(DamageInfo damageInfo, StatisticsHolder statisticsHolder)
        {

            return 0;
        }
    }
}
