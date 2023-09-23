using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI;
using WRA.UI.PanelsSystem;

public class ManualTestCinematicCameraPanel : MonoBehaviour
{
    private void Awake()
    {
        PanelManager.Instance.OpenPanel<CinematicCameraPanel, CinematicCameraData>(new CinematicCameraData() { StartAsShow = true});
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PanelManager.Instance.GetPanel<CinematicCameraPanel>().ShowCurtains();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            PanelManager.Instance.GetPanel<CinematicCameraPanel>().HideCurtains();
        }
    }
}
