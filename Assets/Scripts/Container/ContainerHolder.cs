using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerHolder : MonoBehaviour
{
    protected Container container;
    

    public void SetContainer(Container container)
    {
        this.container = container;
    }
}
