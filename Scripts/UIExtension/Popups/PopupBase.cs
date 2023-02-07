using UnityEngine;
using WRACore.Patterns;

namespace WRACore.UIExtension.Popups
{
    public abstract class PopupBase<T> : MonoBehaviourSingletonAutoLoadUI<T> where T : MonoBehaviour
    {
        public abstract void Open();

        public abstract void Close();
    }
}
