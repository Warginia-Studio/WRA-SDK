using System.Collections.Generic;
using UnityEngine;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Managment;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.Controls.Containers;
using WRA.UI.DragDropSystem.Dragables;
using WRA.UI.DragDropSystem.Dropables;

namespace WRA.UI.DragDropSystem.Controllers
{
    public abstract class BaseSlotsController<T1,T2> : MonoBehaviour where T1 : ContainerSlot<T2> where T2 : ContainerItem
    {
        public Transform ContainerParrent => HoldingContainer.transform;
        public Container<T1, T2> HoldingContainer { get; protected set; }
        public BaseDropable<T1, T2>[] Dropables;
        public SlotStatusManager SlotStatusManager => slotStatusManager;

        [SerializeField] protected Transform dragablesParrent;
        [SerializeField] protected Transform draggingParrent;
        [SerializeField] protected SlotStatusManager slotStatusManager;
        
        [SerializeField] protected BaseDragable<T1, T2> baseDragablePrefab;

        protected List<BaseDragable<T1, T2>> spawnedDragables = new List<BaseDragable<T1, T2>>();

        protected virtual void Awake()
        {
            if (draggingParrent != null && baseDragablePrefab != null)
            {
                baseDragablePrefab.SetParrents(draggingParrent, draggingParrent);
            }
        }


        public abstract void Open(Container<T1, T2> container);
        public abstract void Close();
        public abstract void InitContainer();

        protected abstract void OnContainerChanged();
    }
}
