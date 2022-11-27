using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerWindowIniter<T> : MonoBehaviour
{
    private Container.Container<T> container; 

    public void InitContainer(Container.Container<T> container)
    {
        this.container = container;
    }
}
