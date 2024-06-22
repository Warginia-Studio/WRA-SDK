using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;

public class PanelFragmentSetAsLastSibling : PanelFragmentBase
{
    [SerializeField] private bool moveOnOpenOtherPanel = true;
    public override void OnFragmentInit()
    {
        base.OnFragmentInit();
        InitOnOntherPanel();
        // ParentPanel.OnOpenEvent.AddListener(OnThisPanelShow);
        ParentPanel.OnShowEvent.AddListener(OnThisPanelShow);
    }

    private void InitOnOntherPanel()
    {
        if (!moveOnOpenOtherPanel)
            return;
        var panelManager = ParentPanel.PanelManager;
        panelManager.OnPanelOpen.AddListener(OnOtherPanelOpened);
        panelManager.OnPanelShow.AddListener(OnOtherPanelOpened);
    }

    private void OnDestroy()
    {
        var panelManager = ParentPanel.PanelManager;
        panelManager.OnPanelOpen.RemoveListener(OnOtherPanelOpened);
        panelManager.OnPanelShow.RemoveListener(OnOtherPanelOpened);
    }

    private void OnOtherPanelOpened(PanelBase panel)
    {
        ParentPanel.transform.SetAsLastSibling();
    }
    
    private void OnThisPanelShow()
    {
        ParentPanel.transform.SetAsLastSibling();
    }
}
