using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using DependentObjects.ScriptableObjects.Profiles;
using Managment;
using UIExtension.Controls.DD.Dragables;
using UIExtension.Controls.DD.Dropables;
using UnityEngine;

namespace UIExtension.Controls.DD.Controllers
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
        


        public override void InitContainer()
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

            // var myTransform = GetComponent<RectTransform>();
            // if (dragablesParrent == null || dragablesParrent.serializedProperty)
            // {
            //     var v = new GameObject("Dragables Parrent inventory").GetComponent<RectTransform>();
            //     
            //     v.parent = transform.parent;
            //     v.pivot = myTransform.pivot;
            //     v.anchorMin = myTransform.anchorMin;
            //     v.anchorMax = myTransform.anchorMax;
            //     v.position = transform.position;
            //     v.sizeDelta = myTransform.sizeDelta;
            // }
            //
            // if (draggingParrent == null || draggingParrent.serializedProperty)
            // {
            //     var v = new GameObject("Dragging Parrent inventory").GetComponent<RectTransform>();
            //     
            //     v.parent = transform.parent;
            //     v.pivot = myTransform.pivot;
            //     v.anchorMin = myTransform.anchorMin;
            //     v.anchorMax = myTransform.anchorMax;
            //     v.position = transform.position;
            //     v.sizeDelta = myTransform.sizeDelta;
            // }
            //
            // EditorSceneManager.MarkAllScenesDirty();
        }
        

        
        // TODO: optimatization
        protected override void OnContainerChanged()
        {
            var items = HoldingContainer.GetSlots();

            int itemCount = spawnedDragables.Count - items.Length;

            for (int i = 0; i < -itemCount; i++)
            {
                var newGo = Instantiate(baseDragablePrefab.serializedProperty.gameObject, dragablesParrent.serializedProperty);
                var id = newGo.GetComponent<ItemDragable>();
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
