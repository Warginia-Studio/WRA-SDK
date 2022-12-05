using System;
using System.Collections.Generic;
using Container;
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
