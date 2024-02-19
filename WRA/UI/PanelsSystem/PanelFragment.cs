using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;

public class PanelFragment : MonoBehaviour
{
    public PanelBase ParentPanel { get; set; }

    public void OnPanelInit(PanelBase panelBase)
    {
        ParentPanel = panelBase;
    }
}
