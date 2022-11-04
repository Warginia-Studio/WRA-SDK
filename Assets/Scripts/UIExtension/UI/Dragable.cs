using System;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIExtension.UI
{
    public abstract class Dragable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected  Color defaultColor = Color.white;
        [SerializeField] protected Color draggingColor = new (1,1,1, 0.7f);
        protected Image image
        {
            get
            {
                if (_image == null)
                {
                    _image = GetComponent<Image>();
                }

                return _image;
            }
        }
        
        protected CanvasGroup canvasGroup
        {
            get
            {
                if (_canvasGroup == null)
                {
                    _canvasGroup = GetComponent<CanvasGroup>();
                }

                return _canvasGroup;
            }
        }

        protected Vector3 offset;
        
        private Image _image;
        private CanvasGroup _canvasGroup;

        public void SetIcon(Sprite sprite)
        {
            image.sprite = sprite;
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            DragDropManager.Instance.BeginDragItem(this);
            _image.color = draggingColor;
            offset = (transform.position - Input.mousePosition);
            canvasGroup.blocksRaycasts = false;
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            DragDropManager.Instance.EndDragItem();
            _image.color = defaultColor;
            canvasGroup.blocksRaycasts = true;
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition + offset;
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            DescriptionManager.Instance.ShowDescription(GetDescription());
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            DescriptionManager.Instance.HideDescription();
        }

        protected abstract string GetDescription();
    }
}
