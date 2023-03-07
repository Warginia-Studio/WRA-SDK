using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using Managment;
using UnityEngine;

namespace DependentObjects.Classes
{
    public class DragData
    {
        public ContainerItem ContainerItem { get; private set; }
        
        public Container<ContainerSlot<ContainerItem>, ContainerItem> Container { get; private set; }
        public Vector3 GrabOffset { get; private set; }

        public DragData(ContainerItem containerItem, Vector3 grabOffset)
        {
            ContainerItem = containerItem;
            GrabOffset = grabOffset;
        }
    }
}
