using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;

public abstract class PanelAnimationBase : MonoBehaviour
{
    public PanelBase ParentPanel { get; set; }

    public void SetPanel(PanelBase panelBase)
    {
        ParentPanel = panelBase;
    }

    public virtual void OnPanelInit()
    {
    }

    public virtual void ShowAnimation(System.Action onComplete)
    {
        onComplete?.Invoke();
    }

    public virtual void HideAnimation(System.Action onComplete)
    {
        onComplete?.Invoke();
    }
    
    public virtual void SetVisible(bool visible)
    {
        
    }
}
