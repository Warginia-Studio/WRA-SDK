using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.UI.PanelsSystem.FadeSystem;

public class FadeManagerTest : MonoBehaviour
{
    private FadeManager fadeManager;
    private void Awake()
    {
        fadeManager = PanelManager.Instance.OpenPanel<FadeManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            fadeManager.FadeIn();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            fadeManager.FadeOut();
        }
    }
}
