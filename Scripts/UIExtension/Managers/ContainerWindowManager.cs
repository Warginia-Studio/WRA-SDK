using System.Linq;
using Container;
using Patterns;
using UIExtension.UI;
using UnityEngine;

namespace UIExtension.Managers
{
    public class ContainerWindowManager<T> : MonoBehaviourSingletonAutoLoadUI<ContainerWindowManager<T>> where T : ContainerItem
    {
        private const string NOT_FOUND_CONTAINER = "Not found container in array with name: ";
        private const string ADVANCED_CONTAINER = "ADVANCED CONTAINER ERROR: ";
        private const string SIMPLE_CONTAINER = "SIMPLE CONTAINER ERROR: ";

        [SerializeField] private ContainerWindowIniter<T>[] simpleContainers;
        [SerializeField] private AdvancedContainerWindowIniter<T>[] advancedContainers;

        public void OpenSimpleContainer(Container<T> container, string containerName)
        {
            var containerWindow = simpleContainers.Where(ctg => ctg.gameObject.name == containerName).First();
            if (containerWindow == null)
            {
                Debug.Log(SIMPLE_CONTAINER + NOT_FOUND_CONTAINER + containerName);
                return;
            }

            containerWindow.InitContainer(container);

        }

        public void OpenAdvancedContainer(Container<T> container1, Container<T> container2, string containerName)
        {
            var containerWindow = advancedContainers.Where(ctg => ctg.gameObject.name == containerName).First();
            if(containerWindow== null)
            {
                Debug.Log(ADVANCED_CONTAINER + NOT_FOUND_CONTAINER + containerName);
                return;
            }

            containerWindow.InitContainer(container1, container2);
        }
    }
}
