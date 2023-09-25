using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.UI.PanelsSystem.SubPanels;

public class SubViewTest : MonoBehaviour
{
    private void Awake()
    {
        PanelManager.Instance.OpenPanel<SubViewsPanelBase>();
    }
}
