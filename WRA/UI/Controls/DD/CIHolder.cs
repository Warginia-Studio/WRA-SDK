using System;
using Unity.Collections;
using UnityEngine;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.DragDropSystem.Controllers;

namespace WRA.UI.Controls.DD
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class CIHolder<TSlot, TItem> : MonoBehaviour where TSlot : ContainerSlot<TItem> where TItem : ContainerItem
    {
        // public Container<TSlot, TItem> ParrentContainer  { get; protected set; }
        public BaseSlotsController<TSlot, TItem> ParrentSlotsController => parrentSlotsController;
        
        public TItem HoldingItem  { get; protected set; }
    
        public Type HoldingType { get; protected set; }
        
        [SerializeField][ReadOnly] private BaseSlotsController<TSlot, TItem> parrentSlotsController;

        protected RectTransform rectTransform;

        protected virtual void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public virtual void SetInfo(BaseSlotsController<TSlot, TItem> container, TItem item = null)
        {
            HoldingItem = item;
            parrentSlotsController = container;
            HoldingType = item?.GetType();
            if (item != null)
            {
                var size = (DragDropProfile.Instance.CellSize * item.Size);
                rectTransform.sizeDelta = size;
            }
            // transform.localScale = new Vector3(size.x, size.y, 0);
        }
    }
}
