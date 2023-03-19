using System.Linq;
using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using Managment;
using UIExtension.Controls.DD.Dragables;
using UIExtension.Controls.DD.Dropables;

namespace UIExtension.Controls.DD.Controllers
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
            OnContainerChanged();
        }

        public override void Close()
        {
            HoldingContainer.OnContainerChanged.RemoveListener(OnContainerChanged);
        }

        public override void InitContainer()
        {
            var newDropables = transform.GetComponentsInChildren<DropableArmable>();
            if (Dropables.Length != newDropables.Length)
                Dropables = newDropables;
        
            for (int i = 0; i < Dropables.Length; i++)
            {
                var armable = Dropables[i] as DropableArmable;
                (Dropables[i] as DropableArmable).InitID(i);
                armable.SetInfo(this,null);
            }
        }

        protected override void OnContainerChanged()
        {
            var items = HoldingContainer.GetSlots();

            int itemCount = spawnedDragables.Count - items.Length;

            for (int i = 0; i < -itemCount; i++)
            {
                var newGo = Instantiate(baseDragablePrefab.serializedProperty.gameObject, dragablesParrent.serializedProperty);
                var id = newGo.GetComponent<ArmableDragable>();
                spawnedDragables.Add(id);
            }
            
            int removedItems = 0;
            
            for (int i = 0; removedItems < itemCount && spawnedDragables.Count > 0; i++)
            {
                Destroy(spawnedDragables[i].gameObject);
                spawnedDragables.RemoveAt(i);
                removedItems++;
                i--;
            }

            // for (int i = 0; i < spawnedDragables.Count; i++)
            // {
            //     Destroy(spawnedDragables[i].gameObject);
            //     spawnedDragables.RemoveAt(i);
            //     i--;
            // }

            var dropablesList = Dropables.ToList();

            for (int i = 0; i < items.Length; i++)
            {

                var newPosition = dropablesList.Find(ctg => (ctg as DropableArmable)?.SlotID == items[i].SlotId);
                // newGo.transform.localPosition = new Vector3(newPosition.x, newPosition.y);
                
                spawnedDragables[i].SetParrents(dragablesParrent.serializedProperty, dragablesParrent.serializedProperty);
                spawnedDragables[i].SetInfo(this, items[i].Item);
                spawnedDragables[i].SetBasePosition(newPosition.transform.localPosition);
            }
        }
    }
}
