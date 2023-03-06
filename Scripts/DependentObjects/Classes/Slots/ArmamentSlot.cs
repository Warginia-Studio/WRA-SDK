using DependentObjects.ScriptableObjects.Managment;

namespace DependentObjects.Classes.Slots
{
    public class ArmamentSlot : ContainerSlot<ArmableItem>
    {
        public int SlotId => slotId;
    
        protected int slotId = -1;
        public ArmamentSlot(ArmableItem containerItem, int id) : base(containerItem)
        {
            slotId = id;
        }
    }
}
