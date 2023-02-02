using System.Linq;
using Container;
using DependentObjects.Structs;
using Patterns;
using UIExtension.UI;
using UIExtension.UI.Containers;
using UnityEngine;

namespace UIExtension.Managers
{
    public class ContainerWindowManager : MonoBehaviourSingletonAutoLoadUI<ContainerWindowManager>
    {
        private const string NOT_FOUND_CONTAINER = "Not found container in array with name: ";
        private const string ADVANCED_CONTAINER = "ADVANCED CONTAINER ERROR: ";
        private const string SIMPLE_CONTAINER = "SIMPLE CONTAINER ERROR: ";

        [SerializeField] private ContainerWindowIniterGenerated[] simpleContainers;
        [SerializeField] private AdvancedContainerWindowIniter[] advancedContainers;

        public void OpenContainers(params OpenContainerInfo[] containerInfo)
        {
            
        }

        public void OpenSimpleContainer(Container.Container container, string containerName)
        {
            var containerWindow = simpleContainers.Where(ctg => ctg.gameObject.name == containerName).First();
            if (containerWindow == null)
            {
                Debug.Log(SIMPLE_CONTAINER + NOT_FOUND_CONTAINER + containerName);
                return;
            }

            containerWindow.InitContainer(container);

        }

        public void OpenAdvancedContainer(Container.Container container1, Container.Container container2, string containerName)
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
