using System;
using System.Collections;
using DependentObjects.Classes;
using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using UIExtension.Controls.Dragables.Controllers;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility.CustomAttributes.CustomProperty;

namespace UIExtension.Controls.Dragables.Dragables
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BaseDragable<TSlot, TItem> : CIHolder<TSlot, TItem>, IBeginDragHandler, IDragHandler,
        IEndDragHandler where TSlot : ContainerSlot<TItem> where TItem : ContainerItem
    {
        public Vector3 GrabOffset { get; private set; }
        
        [CustomSerializedField(true)][SerializeField] protected CustomObjectProperty<Image> itemIcon;

        protected Vector3 basePosition;

        protected CanvasGroup canvasGroup;
        protected bool grabbed = false;

        protected Transform draggingParrent;
        protected Transform dragableParrent;
        protected Canvas canvas;

        protected override void Awake()
        {
            base.Awake();
            basePosition = transform.position;
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponent<Canvas>();
        }

        protected void OnDestroy()
        {
            
        }

        public override void SetInfo(BaseSlotsController<TSlot, TItem> container, TItem item = default(TItem))
        {
            base.SetInfo(container, item);

            itemIcon.serializedProperty.sprite = item.Icon;
        }

        public void SetParrents(Transform draggingParrent, Transform dragableParrent)
        {
            this.draggingParrent = draggingParrent;
            this.dragableParrent = dragableParrent;
        }

        public void ResetPosition()
        {
            transform.localPosition  = basePosition;
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 0.4f;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            transform.parent = draggingParrent;
            GrabOffset = transform.position - Input.mousePosition;
            grabbed = true;
            DragDropManager.Instance.BeginDragItem(new DragData(HoldingItem, GrabOffset));
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition + GrabOffset;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            grabbed = false;
            transform.parent = dragableParrent;

            StartCoroutine(DelayResetPosition());
            
        }

        private IEnumerator DelayResetPosition()
        {
            yield return null;
            ResetPosition();
            DragDropManager.Instance.EndDragItem();
        }

        public void SetBasePosition(Vector2 position)
        {
            transform.localPosition = position;
            basePosition = position;
        }
    }
}
