using System;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;

namespace UIExtension.Controls.Containers
{
    public abstract class ContainerHolder : MonoBehaviour
    {
        public Container.Container Container => container;
        public ContainerItem HoldingItem => holdingItem;
        public Type HoldingType;
        
        protected Container.Container container;
        protected ContainerItem holdingItem;
    
        // public virtual void InitContainerHolder(Container.Container container, ContainerSlot holdingItem)
        // {
        //     this.container = container;
        //     this.holdingItem = holdingItem == null ? null : holdingItem.Item;
        // }

        public abstract void Reset();
    }
}
