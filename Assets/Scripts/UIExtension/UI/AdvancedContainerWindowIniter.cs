using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedContainerWindowIniter<T> : MonoBehaviour
{
    [SerializeField] private ContainerWindowIniter<T> containerWindow1;
    [SerializeField] private ContainerWindowIniter<T> containerWindow2;

    public void InitContainer(Container.Container<T> container1, Container.Container<T> container2)
    {
        containerWindow1.InitContainer(container1);
        containerWindow2.InitContainer(container2);
    }
}
