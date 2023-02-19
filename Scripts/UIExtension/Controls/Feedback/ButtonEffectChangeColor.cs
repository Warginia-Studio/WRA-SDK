using DG.Tweening;
using UnityEngine;

namespace UIExtension.Controls.Feedback
{
    public class ButtonEffectChangeColor : ButtonEffectBase
    {
        [SerializeField] private Color activeColor;

        [SerializeField] private Color deactiveColor;

        [SerializeField] private Color pointerEnterColor;

        private bool state = false;

        public override void ChangedStatus(bool active)
        {
            controlledObject.color = active ? activeColor : deactiveColor;
            state = active;
        }

        public override void PointerEnterEffect()
        {
            controlledObject.color = pointerEnterColor;
        }

        public override void PointerExitEffect()
        {
            controlledObject.color = state ? activeColor : deactiveColor;
        }
    }
}
