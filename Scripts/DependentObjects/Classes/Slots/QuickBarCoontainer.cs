using DependentObjects.Interfaces;
using DependentObjects.Interfaces.Items;
using DependentObjects.ScriptableObjects.Managment;
using Managment;

namespace DependentObjects.Classes.Slots
{
    public class QuickBarCoontainer : Container<ContainerSlot<ContainerItem>, ContainerItem>
    {
        public override bool TryAddItem(ContainerItem containerItem)
        {
            var checkUseable = containerItem as IUseableItem;
            if (checkUseable == null)
                return false;
        

            return true;
        }

        public override bool TryAddItemAtSlot(ContainerItem containerItem, int position)
        {
            var checkUseable = containerItem as IUseableItem;
            if (checkUseable == null)
                return false;
        

            return true;
        }

        public override bool TryMoveItem(ContainerItem containerItem, int slotId)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsPossibleToAddItemAtSlot(ContainerItem containerItem, int slotId)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsPossibleToMoveItem(ContainerItem containerItem, int slotId)
        {
            throw new System.NotImplementedException();
        }


        public override bool TryRemoveItem(ContainerItem containerItem)
        {
            throw new System.NotImplementedException();
        }

        public override ContainerItem[] GetItems()
        {
            throw new System.NotImplementedException();
        }

        public override ContainerSlot<ContainerItem>[] GetSlots()
        {
            throw new System.NotImplementedException();
        }

        protected override bool CheckSlot(ContainerItem item, int slotId)
        {
            throw new System.NotImplementedException();
        }

        protected int FindFreeSlot()
        {
            return 0;
        }
    }
}
