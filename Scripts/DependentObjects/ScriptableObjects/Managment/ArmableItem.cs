using DependentObjects.Enums;
using UnityEngine;

namespace DependentObjects.ScriptableObjects.Managment
{
    [CreateAssetMenu(menuName = "thief01/Inventory/Armable")]
    public class ArmableItem : Item
    {
        public ArmamentCategory ArmamentCategory;
    }
}
