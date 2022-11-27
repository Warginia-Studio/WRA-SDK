using UnityEngine;

namespace Container
{
    public class ContainerHolder : MonoBehaviour
    {
        public Container Container => container;
        
        protected Container container;
    
        public void SetContainer(Container container)
        {
            this.container = container;
        }
    }
}
