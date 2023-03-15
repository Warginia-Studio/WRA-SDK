using DependentObjects.Classes;
using DependentObjects.Enums;
using DependentObjects.Structs;
using UnityEngine;

namespace DependentObjects.ScriptableObjects.Managment
{
    [CreateAssetMenu(menuName = "thief01/Inventory/Armable")]
    public class ArmableItem : Item
    {
        public ArmamentCategory ArmamentCategory;
        public StatisticsHolder StatisticInfo;

        public override string GetDescription(Transform parrent)
        {

            return ItemName + Description;
        }
    }
}
