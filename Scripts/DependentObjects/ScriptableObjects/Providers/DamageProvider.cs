using System.Collections;
using System.Collections.Generic;
using DependentObjects.Classes;
using DependentObjects.Classes.ResourcesInfos;
using UnityEngine;

[CreateAssetMenu(menuName = "thief01/Providers/Damage Provider" , fileName = "Damage Provider")]
public class DamageProvider : ScriptableObject
{
    public virtual float CalculateDamage(DamageInfo damageInfo, StatisticsHolder statisticsHolder)
    {

        return 0;
    }
}
