using System;
using DG.Tweening;
using UnityEngine;

namespace WRA.UI_Extensions.PanelsSystem.PanelAnimations
{
    public class PanelAnimationMove : PanelAnimationBase
    {
        // Todo: Add handle EASE type
    
        [SerializeField] protected Vector2 showPosition;
        [SerializeField] protected Vector2 hidePosition;
        [SerializeField] protected float showSpeed = 1;
        [SerializeField] protected float hideSpeed = 1;
    
        protected RectTransform rectTransform;
    
        public override void OnPanelCreated()
        {
            rectTransform = GetComponent<RectTransform>();
            base.OnPanelCreated();
        }

        public override void ShowAnimation(Action onComplete)
        {
            OnStatusChangedEvent(PanelStatus.ShowingAnimation);
            var pos = rectTransform.anchoredPosition;
            var tweenerCore = DOTween.To(() => pos, x => pos = x, showPosition, showSpeed);
            tweenerCore.onUpdate += () => rectTransform.anchoredPosition = pos;
            tweenerCore.onComplete += () =>
            {
                OnStatusChangedEvent(PanelStatus.Show);
                onComplete?.Invoke();
            };
        }

        public override void HideAnimation(Action onComplete)
        {
            OnStatusChangedEvent(PanelStatus.HidingAnimation);
            var pos = rectTransform.anchoredPosition;
            var tweenerCore = DOTween.To(() => pos, x => pos = x, hidePosition, hideSpeed);
            tweenerCore.onUpdate += () => rectTransform.anchoredPosition = pos;
            tweenerCore.onComplete += () =>
            {
                OnStatusChangedEvent(PanelStatus.Hide);
                onComplete?.Invoke();
            };
        }
    
        public override void SetVisible(bool visible)
        {
            rectTransform.anchoredPosition = visible ? showPosition : hidePosition;
            if(visible)
            {
                OnShow?.Invoke();
            }
            else
            {
                OnHide?.Invoke();
            }
        }
    }
}
