using System;
using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using Managment;
using UnityEngine;

namespace UIExtension.Controls.Dragables
{
    public abstract class CIHolder<TSlot, TItem> : MonoBehaviour where TSlot : ContainerSlot<TItem> where TItem : ContainerItem
    {
        public Container<TSlot, TItem> ParrentContainer  { get; protected set; }
        public TItem HoldingItem  { get; protected set; }
    
        public Type HoldingType { get; protected set; }

        public virtual void SetInfo(Container<TSlot, TItem>  container, TItem item = null)
        {
            HoldingItem = item;
            ParrentContainer = container;
            HoldingType = item?.GetType();
        }
    }
}
