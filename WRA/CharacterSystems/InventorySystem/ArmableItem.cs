using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA.CharacterSystems.InventorySystem
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Inventory/Armable")]
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
