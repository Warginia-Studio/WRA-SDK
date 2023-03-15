using System;
using System.Collections.Generic;
using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using Managment;
using UIExtension.Controls.Dragables.Dragables;
using UIExtension.Controls.Dragables.Dropables;
using UnityEngine;
using Utility.CustomAttributes.CustomProperty;

namespace UIExtension.Controls.Dragables.Controllers
{
    public abstract class BaseSlotsController<T1,T2> : MonoBehaviour where T1 : ContainerSlot<T2> where T2 : ContainerItem
    {
        public Container<T1, T2> HoldingContainer { get; protected set; }
        public BaseDropable<T1, T2>[] Dropables;
        public SlotStatusManager SlotStatusManager => slotStatusManager.serializedProperty;

        [SerializeField][CustomSerializedField(true)] protected CustomObjectProperty<Transform> dragablesParrent;
        [SerializeField][CustomSerializedField(true)] protected CustomObjectProperty<Transform> draggingParrent;
        [SerializeField][CustomSerializedField(true)] protected CustomObjectProperty<SlotStatusManager> slotStatusManager;
        
        [SerializeField][CustomSerializedField(true)] protected CustomObjectProperty<BaseDragable<T1, T2>> baseDragablePrefab;

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
