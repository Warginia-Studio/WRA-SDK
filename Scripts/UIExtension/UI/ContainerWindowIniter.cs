using Container;
using UnityEngine;

namespace UIExtension.UI
{
    public class ContainerWindowIniter : MonoBehaviour
    {
        private Container.Container container; 

        public void InitContainer(Container.Container container)
        {
            this.container = container;
        }
    }
}
