using UIExtension.Controls.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UIExtension.Controls.Feedback
{
    [RequireComponent(typeof(ButtonBase))]
    public abstract class ButtonEffectBase : MonoBehaviour
    {
        [SerializeField] protected Graphic controlledObject;
    
        protected ButtonBase buttonBase;
        private void Awake()
        {
            buttonBase = GetComponent<ButtonBase>();
            buttonBase.OnStatusChanged.AddListener(ChangedStatus);
        }

        private void OnDestroy()
        {
            buttonBase.OnStatusChanged.RemoveListener(ChangedStatus);
        }

        public abstract void ChangedStatus(bool active);
    }
}
