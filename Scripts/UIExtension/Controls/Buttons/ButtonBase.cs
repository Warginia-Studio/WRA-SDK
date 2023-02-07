using UnityEngine;
using UnityEngine.Events;

namespace WRACore.UIExtension.Controls.Buttons
{
    public abstract class ButtonBase : MonoBehaviour
    {
        public UnityEvent<bool> OnStatusChanged = new  UnityEvent<bool>();
        public bool IsActive => isActive;

        protected bool isActive;
    }
}
