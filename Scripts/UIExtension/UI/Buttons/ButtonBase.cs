using UIExtension.UI.Feedback;
using UnityEngine.Events;

namespace UIExtension.UI.Buttons
{
    public abstract class ButtonBase : ButtonStatusBase
    {
        public UnityEvent Onclick = new UnityEvent();
        public UnityEvent<bool> OnStatusChanged = new UnityEvent<bool>();
    
        public bool IsActive => isActive;

        protected bool isActive;
    }
}
