using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.Events;
using WRA.General.Patterns;
using WRA.UI;
using WRA.Utility.Diagnostics;

public class PanelManager : MonoBehaviourSingletonMustExist<PanelManager>
{
    public UnityEvent<PanelBase> OnPanelOpen, OnPanelShow, OnPanelHide, OnPanelClose;
    
    // TODO: Do logs as const
    private const string FIRST_LOG = "";
    private const string SECOND_LOG = "";
    
    // TODO: Resource paths to panel
    private const string path1 = "";
    private const string path2 = "";
    
    private List<PanelBase> openedPanels = new List<PanelBase>();

    public PanelBase OpenPanel<T, TData>(TData data, bool startAsHide = false) where T : PanelBase where TData : PanelDataBase
    {
        var panel = GetPanel<T>();
        if (panel != null)
        {
            WraDiagnostics.LogWarning($"Panel {typeof(T).FullName} is opened.");
        }
        else
        {
            panel = LoadPanelFromResources<T>();
            panel.Open(data);

            if (startAsHide)
            {
                HidePanel<T, TData>(data);
            }
        }
        
        OnPanelOpen.Invoke(panel);
        return panel;
    }

    public PanelBase ShowPanel<T, TData>(TData data, bool openIfIsOff = false) where T : PanelBase where TData : PanelDataBase
    {
        var checkData = IsPanelOpened<T>();

        if (checkData.opened)
        {
            checkData.panel.gameObject.SetActive(true);
            checkData.panel.OnShow(data);
        }
        else if (openIfIsOff)
        {
            return OpenPanel<T, TData>(data);
        }

        OnPanelShow.Invoke(checkData.panel);
        return checkData.panel;
    }

    public PanelBase HidePanel<T, TData>(TData data) where T : PanelBase where TData : PanelDataBase
    {
        var checkData = IsPanelOpened<T>();

        if (checkData.opened)
        {
            checkData.panel.gameObject.SetActive(false);
            checkData.panel.OnHide(data);
        }
        
        OnPanelHide.Invoke(checkData.panel);
        return checkData.panel;
    }

    public PanelBase GetPanel<T>() where T : PanelBase
    {
        if (openedPanels == null)
        {
            return null;
        }
        
        return openedPanels.Find(ctg => ctg is T);
    }

    public void ClosePanel<T, TData>(TData data) where T : PanelBase where TData : PanelDataBase
    {
        var checkData = IsPanelOpened<T>();

        if (checkData.opened)
        {
            OnPanelClose.Invoke(checkData.panel);
            DestroyPanel(checkData.panel, data);
        }
    }

    private (bool opened, PanelBase panel) IsPanelOpened<T>([CallerMemberName]string callerMemberName = "") where T : PanelBase
    {
        var panel = GetPanel<T>();

        if (panel == null)
        {
            WraDiagnostics.LogError($"Panel {typeof(T).FullName} isn't opened. Can't do action {callerMemberName}.", Color.yellow);
            return (false, panel);
        }

        return (true, panel);
    }

    private T LoadPanelFromResources<T>() where T : PanelBase
    {
        var panel = TryInitialize<T>($"SDK/Panels/{typeof(T).Name}");
        
        openedPanels.Add(panel);
        return panel;
    }

    private T TryInitialize<T>(string path) where T : PanelBase
    {
        var loadedPanel = Resources.Load<T>(path);
        if (loadedPanel == null)
        {
            WraDiagnostics.LogError($"Not found panel at path: {path}", Color.red);
            return null;
        }

        var createdPanel = Instantiate(loadedPanel, transform);
        
        WraDiagnostics.LogError($"Spawned panel from: {path}", Color.green);

        return createdPanel;
    }

    private void DestroyPanel(PanelBase panelBase, PanelDataBase dataBase)
    {
        panelBase.Close(dataBase);
        openedPanels.Remove(panelBase);
        Destroy(panelBase.gameObject);
    }
}
