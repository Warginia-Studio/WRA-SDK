using System.Collections.Generic;
using DependentObjects.Enums;
using DependentObjects.ScriptableObjects;
using UnityEngine;

namespace Inventory
{
    public class Armament : Container.Container
    {
        public List<ArmamentCategory> slots = new List<ArmamentCategory>();
        private List<ArmableItem> armableItems = new List<ArmableItem>();

        public override bool TryAddItemAtPosition(ContainerItem containerItem, Vector2Int position)
        {
            var armamentItem = containerItem as ArmableItem;
            if (armamentItem == null && IsOutsideOfInventory(containerItem, position))
                return false;
            if (slots[position.x] == armamentItem.ArmamentCategory)
            {
                armableItems.Add(armamentItem);
            }

            TryAddItemAtPosition(containerItem, position);
            return true;
        }
        
        public override bool TryRemoveItem(ContainerItem containerItem)
        {
            var armamentItem = containerItem as ArmableItem;
            if (armamentItem == null)
                return false;
            var id =armableItems.FindIndex(ctg => ctg == armamentItem);
            if (id == -1)
                return false;
            armableItems.RemoveAt(id);
            TryRemoveItem(containerItem);

            return true;
        }

        public ArmableItem[] GetArmableItems()
        {
            return armableItems.ToArray();
        }
        
        protected override bool IsOutsideOfInventory(ContainerItem item, Vector2Int position)
        {
            return position.x >= xSize;
        }

        protected override bool CheckSlot(ContainerItem item, Vector2Int position)
        {
            return base.slots.Find(ctg => ctg.Position.x == position.x) != null;
        }
    }
}