using DependentObjects.ScriptableObjects;
using UnityEngine;

namespace Container
{
    public abstract class ContainerHolder : MonoBehaviour
    {
        public Container Container => container;
        public ContainerItem HoldingItem => holdingItem;
        
        protected Container container;
        protected ContainerItem holdingItem;
    
        public virtual void InitContainerHolder(Container container, ContainerSlot holdingItem)
        {
            this.container = container;
            this.holdingItem = holdingItem == null ? null : holdingItem.Item;
        }

        public abstract void Reset();
    }
}
