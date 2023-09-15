using System.Collections.Generic;
using UnityEngine;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Managment;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.Controls.DD.Dragables;
using WRA.UI.Controls.DD.Dropables;
using WRA.Utility.CustomAttributes.CustomProperty;

namespace WRA.UI.Controls.DD.Controllers
{
    public abstract class BaseSlotsController<T1,T2> : MonoBehaviour where T1 : ContainerSlot<T2> where T2 : ContainerItem
    {
        public Transform ContainerParrent => HoldingContainer.transform;
        public Container<T1, T2> HoldingContainer { get; protected set; }
        public BaseDropable<T1, T2>[] Dropables;
        public SlotStatusManager SlotStatusManager => slotStatusManager.serializedProperty;

        [SerializeField][CSerializedField(true)] protected COP<Transform> dragablesParrent;
        [SerializeField][CSerializedField(true)] protected COP<Transform> draggingParrent;
        [SerializeField][CSerializedField(true)] protected COP<SlotStatusManager> slotStatusManager;
        
        [SerializeField][CSerializedField(true)] protected COP<BaseDragable<T1, T2>> baseDragablePrefab;

        protected List<BaseDragable<T1, T2>> spawnedDragables = new List<BaseDragable<T1, T2>>();

        protected virtual void Awake()
        {
            if (draggingParrent != null && baseDragablePrefab != null)
            {
                baseDragablePrefab.serializedProperty.SetParrents(draggingParrent.serializedProperty, draggingParrent.serializedProperty);
            }
        }


        public abstract void Open(Container<T1, T2> container);
        public abstract void Close();
        public abstract void InitContainer();

        protected abstract void OnContainerChanged();
    }
}
