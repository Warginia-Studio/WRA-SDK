using System;
using UnityEngine;
using UnityEngine.Events;

namespace WRA.UI.PanelsSystem.PanelAnimations
{
    public abstract class PanelAnimationBase : PanelFragmentBase
    {
        public UnityEvent OnShow;
        public UnityEvent OnHide;
        public UnityEvent<PanelStatus> OnStatusChanged;
        
        public bool IsAnimating => Status is PanelStatus.ShowingAnimation or PanelStatus.HidingAnimation;
        public PanelStatus Status { get; protected set; }
        
        public bool UseAnimationFromPanel => useAnimationFromPanel;

        [SerializeField] private bool useAnimationFromPanel = true;
        public void SetPanel(PanelBase panelBase)
        {
            ParentPanel = panelBase;
        }
        
        public override void OnPanelCreated()
        {
            SetVisible(!false);
        }

        public virtual void ShowAnimation(Action onComplete = null)
        {
            OnStatusChangedEvent(PanelStatus.Show);
            onComplete?.Invoke();
        }

        public virtual void HideAnimation(Action onComplete = null)
        {
            OnStatusChangedEvent(PanelStatus.Hide);
            onComplete?.Invoke();
        }
        
    
        public virtual void SetVisible(bool visible)
        {
            if (visible)
            {
                ShowAnimation(null);
            }
            else
            {
                HideAnimation(null);
            }
        }
    
        protected void OnStatusChangedEvent(PanelStatus newStatus)
        {
            Status = newStatus;
            OnStatusChanged?.Invoke(newStatus);
            switch (newStatus)
            {
                case PanelStatus.Show:
                    OnShow?.Invoke();
                    break;
                case PanelStatus.Hide:
                    OnHide?.Invoke();
                    break;
            }
        }
    }
}
