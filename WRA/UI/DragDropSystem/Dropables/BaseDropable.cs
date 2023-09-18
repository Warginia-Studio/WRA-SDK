using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Slots;

namespace WRA.UI.Controls.DD.Dropables
{
    public abstract class BaseDropable<T1,T2> : CIHolder<T1, T2> , IDropHandler, IPointerEnterHandler, IPointerExitHandler where T1 : ContainerSlot<T2> where T2 : ContainerItem
    {
        public UnityEvent<bool>OnPointerInDropable = new UnityEvent<bool>();
        public UnityEvent OnPointerOutDropable = new UnityEvent();

        protected Type holdingType;

        protected override void Awake()
        {
            holdingType = typeof(T2);
        }

        public abstract bool IsValid();
    
        public abstract void OnDrop(PointerEventData eventData);
        public abstract void UpdateStatus(bool enter);
        public abstract bool IsCorrect();

        public void OnPointerEnter(PointerEventData eventData)
        {
            UpdateStatus(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UpdateStatus(false);
        }
    }
}
