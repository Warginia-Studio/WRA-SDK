using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.Controls;
using WRA.UI.Controls.DD;
using WRA.UI.DragDropSystem.Controllers;
using WRA.Utility.CustomAttributes.CustomProperty;

namespace WRA.UI.DragDropSystem.Dragables
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BaseDragable<TSlot, TItem> : CIHolder<TSlot, TItem>, IBeginDragHandler, IDragHandler,
        IEndDragHandler, IDescriptable where TSlot : ContainerSlot<TItem> where TItem : ContainerItem
    {
        public Vector3 GrabOffset { get; protected set; }
        
        [CSerializedField(true)][SerializeField] protected COP<Image> itemIcon;

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

        public virtual void ResetPosition()
        {
            transform.localPosition  = basePosition;
        }


        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 0.4f;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            transform.parent = draggingParrent;
            GrabOffset = transform.position - Input.mousePosition;
            grabbed = true;
            DragDropManager.Instance.BeginDragItem(new DragData(HoldingItem, GrabOffset));
        }
    
        public virtual void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition + GrabOffset;
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            grabbed = false;
            transform.parent = dragableParrent;

            StopAllCoroutines();
            StartCoroutine(DelayResetPosition());
        }
        
        public virtual void SetBasePosition(Vector2 position)
        {
            transform.localPosition = position;
            basePosition = position;
        }
        protected virtual IEnumerator DelayResetPosition()
        {
            yield return null;
            ResetPosition();
            DragDropManager.Instance.EndDragItem();
        }

        public virtual string GetDescription()
        {
            return HoldingItem.GetDescription(ParrentSlotsController.ContainerParrent);
        }
    }
}
