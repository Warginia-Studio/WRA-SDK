using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using Managment;

namespace UIExtension.Controls.DD.Controllers
{
    public class UseableSlotsController : BaseSlotsController<ContainerSlot<ContainerItem>, ContainerItem>
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public override void Open(Container<ContainerSlot<ContainerItem>, ContainerItem> container)
        {
            HoldingContainer = container;
            container.OnContainerChanged.AddListener(OnContainerChanged);
        }

        public override void Close()
        {
            HoldingContainer.OnContainerChanged.RemoveListener(OnContainerChanged);
        }

        public override void InitContainer()
        {
            // var newDropables = transform.GetComponentsInChildren<DropableUseable>();
            // if (Dropables.Length != newDropables.Length)
            //     Dropables = newDropables;
            //
            // for (int i = 0; i < Dropables.Length; i++)
            // {
            //     (Dropables[i] as DropableUseable).InitId();
            // }
        }

        protected override void OnContainerChanged()
        {
            throw new System.NotImplementedException();
        }
    }
}
