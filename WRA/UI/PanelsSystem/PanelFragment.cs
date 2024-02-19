using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;

public abstract class PanelFragment : MonoBehaviour
{
    public PanelBase ParentPanel { get; set; }

    public void SetPanel(PanelBase panelBase)
    {
        ParentPanel = panelBase;
    }

    public abstract void OnPanelInit();
}
