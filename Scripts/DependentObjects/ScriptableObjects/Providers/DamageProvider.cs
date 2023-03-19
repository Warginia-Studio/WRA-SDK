using DependentObjects.Classes.ResourcesInfos;
using DependentObjects.Classes.Statistics;
using UnityEngine;

namespace DependentObjects.ScriptableObjects.Providers
{
    [CreateAssetMenu(menuName = "thief01/Providers/Damage Provider" , fileName = "Damage Provider")]
    public class DamageProvider : ScriptableObject
    {
        public virtual float CalculateDamage(DamageInfo damageInfo, StatisticsHolder statisticsHolder)
        {

            return 0;
        }
    }
}
