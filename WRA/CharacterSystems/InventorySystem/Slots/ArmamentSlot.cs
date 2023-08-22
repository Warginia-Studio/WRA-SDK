namespace WRA.CharacterSystems.InventorySystem.Slots
{
    [System.Serializable]
    public class ArmamentSlot : ContainerSlot<ArmableItem>
    {
        public int SlotId => slotId;
    
        protected int slotId = -1;
        public ArmamentSlot(ArmableItem containerItem, int id) : base(containerItem)
        {
            slotId = id;
        }

        public void SetNewSlotId(int newSlotId)
        {
            slotId = newSlotId;
        }
    }
}
