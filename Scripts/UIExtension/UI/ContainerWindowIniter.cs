using Container;
using UnityEngine;

namespace UIExtension.UI
{
    public class ContainerWindowIniter<T> : MonoBehaviour where T : ContainerItem
    {
        private Container.Container<T> container; 

        public void InitContainer(Container.Container<T> container)
        {
            this.container = container;
        }
    }
}
