using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WRA.UI.PanelsSystem;

public abstract class PanelAnimationBase : MonoBehaviour
{
    public UnityEvent OnShow;
    public UnityEvent OnHide;
    public UnityEvent<PanelAnimationStatus> OnStatusChanged;
    public PanelAnimationStatus Status { get; protected set; }
    public PanelBase ParentPanel { get; set; }

    public void SetPanel(PanelBase panelBase)
    {
        ParentPanel = panelBase;
    }

    public virtual void OnPanelInit()
    {
    }

    public virtual void ShowAnimation(Action onComplete)
    {
        OnStatusChangedEvent(PanelAnimationStatus.Show);
        onComplete.Invoke();
    }

    public virtual void HideAnimation(Action onComplete)
    {
        OnStatusChangedEvent(PanelAnimationStatus.Hide);
        onComplete.Invoke();
    }
    
    public virtual void SetVisible(bool visible)
    {
        
    }
    
    protected void OnStatusChangedEvent(PanelAnimationStatus newStatus)
    {
        Status = newStatus;
        OnStatusChanged?.Invoke(newStatus);
        switch (newStatus)
        {
            case PanelAnimationStatus.Show:
                OnShow?.Invoke();
                break;
            case PanelAnimationStatus.Hide:
                OnHide?.Invoke();
                break;
        }
    }
}
