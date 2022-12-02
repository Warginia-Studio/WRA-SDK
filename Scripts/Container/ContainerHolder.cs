using UnityEngine;

namespace Container
{
    public abstract class ContainerHolder : MonoBehaviour
    {
        public Container Container => container;
        public ContainerItem HoldingItem => holdingItem;
        
        protected Container container;
        protected ContainerItem holdingItem;
    
        public void InitContainerHolder(Container container, ContainerItem holdingItem)
        {
            this.container = container;
            this.holdingItem = holdingItem;
        }

        public abstract void Reset();
    }
}
