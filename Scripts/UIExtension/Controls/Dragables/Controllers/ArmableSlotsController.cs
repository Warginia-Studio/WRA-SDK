using System;
using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using Managment;
using UIExtension.Controls.Dragables.Dropables;

namespace UIExtension.Controls.Dragables.Controllers
{
    public class ArmableSlotsController : BaseSlotsController<ArmamentSlot, ArmableItem>
    {
    
        private void Awake()
        {
        
        }


        public override void Open(Container<ArmamentSlot, ArmableItem> container)
        {
            HoldingContainer = container;
            container.OnContainerChanged.AddListener(OnContainerChanged);
        }

        public override void Close()
        {
            HoldingContainer.OnContainerChanged.RemoveListener(OnContainerChanged);
        }

        public override void InitSlots()
        {
            var newDropables = transform.GetComponentsInChildren<DropableArmable>();
            if (Dropables.Length != newDropables.Length)
                Dropables = newDropables;
        
            for (int i = 0; i < Dropables.Length; i++)
            {
                (Dropables[i] as DropableArmable).InitID(i);
            }
        }

        protected override void OnContainerChanged()
        {
            throw new NotImplementedException();
        }
    }
}
