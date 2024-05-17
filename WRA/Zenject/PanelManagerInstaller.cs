using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using Zenject;

public class PanelManagerInstaller : MonoInstaller
{
    [SerializeField] private PanelManager panelManager;
    
    public override void InstallBindings()
    {
        Container.Bind<PanelManager>().FromInstance(panelManager).AsSingle();
    }
}
