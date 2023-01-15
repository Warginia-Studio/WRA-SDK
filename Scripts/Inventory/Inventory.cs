using System;
using System.Collections.Generic;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;

namespace Inventory
{
    public class Inventory : Container.Container
    {
        private void Awake()
        {
            holdingType = typeof(Item);
        }
    }
}
