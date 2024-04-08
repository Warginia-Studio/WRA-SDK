using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WRA.UI.PanelsSystem;

public abstract class PanelAnimationBase : PanelFragmentBase
{
    public UnityEvent OnShow;
    public UnityEvent OnHide;
    public UnityEvent<PanelAnimationStatus> OnStatusChanged;
    public PanelAnimationStatus Status { get; protected set; }

    public void SetPanel(PanelBase panelBase)
    {
        ParentPanel = panelBase;
    }

    public override void OnFragmentInit()
    {
        base.OnFragmentInit();
        SetVisible(!ParentPanel.GetDataAsType<PanelDataBase>().StartAsHide);
    }

    public virtual void ShowAnimation(Action onComplete = null)
    {
        OnStatusChangedEvent(PanelAnimationStatus.Show);
        onComplete?.Invoke();
    }

    public virtual void HideAnimation(Action onComplete = null)
    {
        OnStatusChangedEvent(PanelAnimationStatus.Hide);
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
