using System;
using System.Collections.Generic;
using System.Linq;
using Container;
using UnityEngine;

namespace UIExtension.UI
{
    [ExecuteInEditMode]
    public class ContainerWindowIniter : MonoBehaviour
    {
        private Container.Container container;

        private int childCount = 0;
        
        private List<Dropable> dropables = new List<Dropable>();
        private void Awake()
        {
            
        }

        private void Update()
        {
            if (transform.childCount != childCount)
            {
                dropables = GetComponentsInChildren<Dropable>().ToList();
                childCount = transform.childCount;
            }
        }

        public void InitContainer(Container.Container container)
        {
            this.container = container;
        }
    }
}
