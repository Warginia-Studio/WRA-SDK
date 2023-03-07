using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects;
using DependentObjects.ScriptableObjects.Managment;
using Managment;
using UIExtension.Controls.Dragables.Dragables;
using UIExtension.Controls.Dragables.Dropables;
using UnityEngine;

namespace UIExtension.Controls.Dragables.Controllers
{
    public class InventorySlotsController : BaseSlotsController<InventorySlot, Item>
    {
        private RectTransform rectTransform;
        private CustomGridLayoutGroup customGridLayoutGroup;

        protected void Awake()
        {
            base.Awake();
            GetComponents();
        
        }

        public override void Open(Container<InventorySlot, Item> container)
        {
            HoldingContainer = container;
            container.OnContainerChanged.AddListener(OnContainerChanged);
            OnContainerChanged();
        }

        public override void Close()
        {
            HoldingContainer.OnContainerChanged.RemoveListener(OnContainerChanged);
        }

        public override void InitSlots()
        {
            if (rectTransform == null || customGridLayoutGroup == null)
                GetComponents();
            
            var newDropables = transform.GetComponentsInChildren<DropableItem>();
            if (Dropables.Length != newDropables.Length)
                Dropables = newDropables;

            int x = 0;
            int y = 0;

            int inRow = (int)(rectTransform.sizeDelta.x / customGridLayoutGroup.cellSize.x);
        
            for (int i = 0; i < Dropables.Length; i++)
            {
                x = i % inRow;
                y = i / inRow;
                (Dropables[i] as DropableItem).InitId(new Vector2Int(x,y), i);
                Dropables[i].SetInfo(this, null);
            }
        }
        
        // TODO: optimatization
        protected override void OnContainerChanged()
        {
            var items = HoldingContainer.GetSlots();

            int itemCount = spawnedDragables.Count - items.Length;

            for (int i = 0; i < -itemCount; i++)
            {
                var newGo = Instantiate(baseDragablePrefab.gameObject, dragablesParrent.serializedProperty);
                var id = newGo.GetComponent<ItemDragable>();
                spawnedDragables.Add(id);
            }
            
            for (int i = 0; i < itemCount; i++)
            {
                spawnedDragables.RemoveAt(i);
                i--;
            }

            // for (int i = 0; i < spawnedDragables.Count; i++)
            // {
            //     Destroy(spawnedDragables[i].gameObject);
            //     spawnedDragables.RemoveAt(i);
            //     i--;
            // }

            for (int i = 0; i < items.Length; i++)
            {
                
                var newPosition = (new Vector2Int(items[i].Position.x, -items[i].Position.y) *
                                   DragDropProfile.Instance.CellSize);
                // newGo.transform.localPosition = new Vector3(newPosition.x, newPosition.y);
                
                spawnedDragables[i].SetParrents(dragablesParrent.serializedProperty, dragablesParrent.serializedProperty);
                spawnedDragables[i].SetInfo(this, items[i].Item);
                spawnedDragables[i].SetBasePosition(newPosition);
                

            }
        }

        private void GetComponents()
        {
            rectTransform = GetComponent<RectTransform>();
            customGridLayoutGroup = GetComponent<CustomGridLayoutGroup>();
        }
    }
}
