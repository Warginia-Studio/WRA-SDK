using System;
using Container;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIExtension.UI
{
    public abstract class Dragable : ContainerHolder, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] protected  Color defaultColor = Color.white;
        [SerializeField] protected Color draggingColor = new (1,1,1, 0.7f);
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

        public void SetIcon(Sprite sprite)
        {
            Image.sprite = sprite;
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            DragDropManager.Instance.BeginDragItem(this);
            image.color = draggingColor;
            offset = (transform.position - Input.mousePosition);
            CanvasGroup.blocksRaycasts = false;
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            DragDropManager.Instance.EndDragItem();
            image.color = defaultColor;
            CanvasGroup.blocksRaycasts = true;
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition + offset;
        }
    }
}
