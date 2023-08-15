using UnityEngine;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Managment;
using WRA.CharacterSystems.InventorySystem.Slots;

namespace WRA.General.Classes
{
    public class DragData
    {
        public ContainerItem ContainerItem { get; private set; }
        
        public Container<ContainerSlot<ContainerItem>, ContainerItem> Container { get; private set; }
        public Inventory InventoryContainer;
        public Armament ArmamentContainer;
        public QuickBarCoontainer QuickBarCoontainer;
        public Vector3 GrabOffset { get; private set; }

        public DragData(ContainerItem containerItem, Vector3 grabOffset)
        {
            ContainerItem = containerItem;
            GrabOffset = grabOffset;
        }

        public void RemoveItemFromPreviousContainer()
        {
            InventoryContainer?.TryRemoveItem(ContainerItem as Item);
            ArmamentContainer?.TryRemoveItem(ContainerItem as ArmableItem);
            QuickBarCoontainer?.TryRemoveItem(ContainerItem as ContainerItem);
        }
    }
}
