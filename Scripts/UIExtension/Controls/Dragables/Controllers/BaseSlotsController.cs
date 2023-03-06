using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using Managment;
using UIExtension.Controls.Dragables.Dropables;
using UnityEngine;

namespace UIExtension.Controls.Dragables.Controllers
{
    public abstract class BaseSlotsController<T1,T2> : MonoBehaviour where T1 : ContainerSlot<T2> where T2 : ContainerItem
    {
        public Container<T1, T2> HoldingContainer { get; protected set; }
        public BaseDropable<T1, T2>[] Dropables;


        public abstract void Open(Container<T1, T2> container);
        public abstract void Close();
        public abstract void InitSlots();

        protected abstract void OnContainerChanged();
    }
}
