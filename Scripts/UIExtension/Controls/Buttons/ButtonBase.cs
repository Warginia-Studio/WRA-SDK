using UnityEngine;
using UnityEngine.Events;

namespace UIExtension.Controls.Buttons
{
    public abstract class ButtonBase : MonoBehaviour
    {
        public UnityEvent<bool> OnStatusChanged = new  UnityEvent<bool>();
        public bool IsActive => isActive;

        protected bool isActive;
    }
}
