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
                transform.localScale = new Vector3(containerItem.Size.x, containerItem.Size.y, 0);
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

        private void Awake()
        {
            
        }

        private void OnDestroy()
        {
            
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            
            DragDropManager.Instance.BeginDragItem(new DraggingData(this, container.HoldingType));
            image.color = DragDropProfile.Instance.DragableColor(true);
            offset = (transform.position - Input.mousePosition);
            CanvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
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
            // reset position
        }
    }
}
