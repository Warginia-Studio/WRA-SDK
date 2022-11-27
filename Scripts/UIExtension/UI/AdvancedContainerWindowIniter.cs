using Container;
using UnityEngine;

namespace UIExtension.UI
{
    public class AdvancedContainerWindowIniter : MonoBehaviour
    {
        [SerializeField] private ContainerWindowIniter containerWindow1;
        [SerializeField] private ContainerWindowIniter containerWindow2;

        public void InitContainer(Container.Container container1, Container.Container container2)
        {
            containerWindow1.InitContainer(container1);
            containerWindow2.InitContainer(container2);
        }
    }
}
