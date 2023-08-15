using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WRA.UI.Controls.Buttons;

namespace WRA.UI.Controls.Feedback
{
    [RequireComponent(typeof(ButtonBase))]
    public abstract class ButtonEffectBase : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
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
        
        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExitEffect();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEnterEffect();
        }

        public abstract void ChangedStatus(bool active);

        public abstract void PointerEnterEffect();

        public abstract void PointerExitEffect();

    }
}
