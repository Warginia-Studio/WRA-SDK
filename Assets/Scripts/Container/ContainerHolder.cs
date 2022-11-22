using UnityEngine;

namespace Container
{
    public class ContainerHolder<T> : MonoBehaviour
    {
        protected Container<T> container;
    
        public void SetContainer(Container<T> container)
        {
            this.container = container;
        }
    }
}
