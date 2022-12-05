using System;
using Container;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIExtension.UI
{
    public sealed class Dragable : ContainerHolder, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public ContainerItem ContainerItem
        {
            get => containerItem;
            set
            {
                containerItem = value;
                Image.sprite = containerItem.Icon;
                transform.localScale = new Vector3(value.Size.x, value.Size.y, 0);
            }
        }

        public Vector2Int InventoryOffset
        {
            get
            {
                Vector2Int inventoryOffset;
                var cellSize = DragDropProfile.Instance.CellSize;
                inventoryOffset = new Vector2Int((int)(offset.x / cellSize.x), (int)(offset.y / cellSize.y));
                return inventoryOffset;
            }
        }

        public int Stacked { get; set; }

        protected Image Image
        {
            get
            {
                if (image == null)
                {
                    image = GetComponent<Image>();
                }

                return image;
            }
        }
        
        protected CanvasGroup CanvasGroup
        {
            get
            {
                if (canvasGroup == null)
                {
                    canvasGroup = GetComponent<CanvasGroup>();
                }

                return canvasGroup;
            }
        }
        
        protected Vector3 offset;
        
        private Image image;
        private CanvasGroup canvasGroup;
        private ContainerItem containerItem;
        private RectTransform rectTransform;
        private Vector2 basicPosition;

        private void Awake()
        {
            GetComponent<RectTransform>().sizeDelta = DragDropProfile.Instance.CellSize;
        }

        private void OnDestroy()
        {
            
        }

        public override void InitContainerHolder(Container.Container container, ContainerSlot slot)
        {
            base.InitContainerHolder(container, slot);
            transform.localPosition = new Vector3(slot.Position.x * DragDropProfile.Instance.CellSize.x,
                -slot.Position.y * DragDropProfile.Instance.CellSize.y, 0);
            basicPosition = transform.localPosition;
            transform.localScale = new Vector3(slot.Item.Size.x, slot.Item.Size.y, 0);
            containerItem = slot.Item;
            Stacked = slot.stack;
            Debug.Log($"Position: {slot.Position*32} , Size: {slot.Item.Size}");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            DragDropManager.Instance.BeginDragItem(this);
            Image.color = DragDropProfile.Instance.DragableColor(true);
            offset = (transform.position - Input.mousePosition);
            CanvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Reset();
            DragDropManager.Instance.EndDragItem();
            image.color = DragDropProfile.Instance.DragableColor(false);;
            CanvasGroup.blocksRaycasts = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition + offset;
        }

        public override void Reset()
        {
            transform.localPosition = basicPosition;
        }
    }
}
