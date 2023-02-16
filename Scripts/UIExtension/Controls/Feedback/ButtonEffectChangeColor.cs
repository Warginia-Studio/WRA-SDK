using DG.Tweening;
using UnityEngine;

namespace UIExtension.Controls.Feedback
{
    public class ButtonEffectChangeColor : ButtonEffectBase
    {
        [SerializeField] private Color activeColor;

        [SerializeField] private Color deactiveColor;

        public override void ChangedStatus(bool active)
        {
            controlledObject.color = active ? activeColor : deactiveColor;
            transform.DOScale(Vector3.one * (active ? 1.1f : 1), 0.1f);
            transform.SetSiblingIndex(5);
        }
    }
}
