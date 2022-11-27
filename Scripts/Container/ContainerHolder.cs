using UnityEngine;

namespace Container
{
    public class ContainerHolder : MonoBehaviour
    {
        protected Container container;
    
        public void SetContainer(Container container)
        {
            this.container = container;
        }
    }
}
