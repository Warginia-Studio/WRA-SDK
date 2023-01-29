using System;
using UIExtension.UI.Feedback;
using UnityEngine;
using UnityEngine.Events;

namespace UIExtension.UI.Buttons
{
    public abstract class ButtonBase : MonoBehaviour
    {
        public UnityEvent Onclick = new UnityEvent();
        public UnityEvent<bool> OnStatusChanged = new UnityEvent<bool>();
    
        public bool IsActive => isActive;

        protected bool isActive;

        public void SetStatus(bool active)
        {
            isActive = active;
            OnStatusChanged.Invoke(isActive);
        }
    }
}
