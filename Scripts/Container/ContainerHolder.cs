using UnityEngine;

namespace Container
{
    public class ContainerHolder<T> : MonoBehaviour where T : ContainerItem
    {
        protected Container<T> container;
    
        public void SetContainer(Container<T> container)
        {
            this.container = container;
        }
    }
}
