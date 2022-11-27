using UnityEngine;

namespace Container
{
    public abstract class ContainerHolder : MonoBehaviour
    {
        public Container Container => container;
        
        protected Container container;
    
        public void SetContainer(Container container)
        {
            this.container = container;
        }

        public abstract void Reset();
    }
}
