using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using WRA.General.Patterns;
using WRA.General.Patterns.Singletons;
using WRA.UI.PanelsSystem.Zenject;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using Zenject;

namespace WRA.UI.PanelsSystem
{
    public class PanelManager : MonoBehaviour
    {
        private const string LOG_TAG = "PanelManager";
        [HideInInspector] public UnityEvent<PanelBase> OnPanelOpen, OnPanelShow, OnPanelHide, OnPanelClose;
    
        // TODO: Do logs as const
        private const string FIRST_LOG = "";
        private const string SECOND_LOG = "";
    
        // TODO: Resource paths to panel
        private const string path1 = "";
        private const string path2 = "";
    
        private List<PanelBase> openedPanels = new List<PanelBase>();
        
        [Inject] private PanelFactory panelFactory;

        // public void LazlyClose(PanelBase panelBase)
        // {
        //     DestroyPanel(panelBase, null);
        // }
        
        public PanelBase OpenPanel(string panelName, PanelDataBase data = null)
        {
            if (IsPanelOpened(panelName))
            {
                return GetPanel(panelName);
            }
            return panelFactory.Create(panelName, data);
        }
        
        public void ShowPanel(string panelName)
        {
            if (IsPanelOpened(panelName))
            {
                GetPanel(panelName).ShowThisPanel();
            }
            else
            {
                OpenPanel(panelName);
            }
        }
        
        public PanelBase GetPanel(string panelName)
        {
            return openedPanels.Find(panel => panel.name == panelName);
        }
        
        public bool IsPanelOpened(string panelName)
        {
            return openedPanels.Exists(panel => panel.name == panelName);
        }
        
        // public T OpenPanel<T>(object data = null, PanelBase parrentPanel = null)
        //     where T : PanelBase
        // {
        //     var panel = GetPanel<T>() as T;
        //     if (panel != null)
        //     {
        //         WraDiagnostics.LogWarning($"Panel {typeof(T).FullName} is opened.", LOG_TAG);
        //         return panel;
        //     }
        //
        //     panel = LoadPanelFromResources<T>() as T;
        //     panel.InitPanelBase(data);
        //     panel.OnOpen();
        //     if (panel == null)
        //         return null;
        //     
        //     if(parrentPanel!=null)
        //         panel.transform.SetParent(parrentPanel.transform);
        //     OnPanelOpen.Invoke(panel);
        //     return panel;
        // }
        //
        // public T ShowPanel<T>(object data = null, bool openIfIsOff = false) where T : PanelBase
        // {
        //     var checkData = IsPanelOpened<T>();
        //
        //     if (checkData.opened)
        //     {
        //         checkData.panel.SetData(data);
        //         checkData.panel.OnShow();
        //     }
        //     else if (openIfIsOff)
        //     {
        //         return OpenPanel<T>(data);
        //     }
        //
        //     OnPanelShow.Invoke(checkData.panel);
        //     return checkData.panel;
        // }
        //
        // public T HidePanel<T>(object data = null) where T : PanelBase
        // {
        //     var checkData = IsPanelOpened<T>();
        //
        //     if (checkData.opened)
        //     {
        //         checkData.panel.SetData(data);
        //         checkData.panel.OnHide();
        //     }
        //
        //     OnPanelHide.Invoke(checkData.panel);
        //     return checkData.panel;
        // }
        //
        // public T GetPanel<T>() where T : PanelBase
        // {
        //     return openedPanels.Find(ctg => ctg is T) as T;
        // }
        //
        // public void ClosePanel<T>(object data = null) where T : PanelBase
        // {
        //     var checkData = IsPanelOpened<T>();
        //
        //     if (checkData.opened)
        //     {
        //         OnPanelClose.Invoke(checkData.panel);
        //         DestroyPanel(checkData.panel, data);
        //     }
        // }
        //
        // private (bool opened, T panel) IsPanelOpened<T>([CallerMemberName]string callerMemberName = "") where T : PanelBase
        // {
        //     var panel = GetPanel<T>() as T;
        //
        //     if (panel == null)
        //     {
        //         WraDiagnostics.LogError($"Panel {typeof(T).FullName} isn't opened. Can't do action {callerMemberName}.", Color.yellow, LOG_TAG);
        //         return (false, panel);
        //     }
        //
        //     return (true, panel);
        // }
        //
        // private T LoadPanelFromResources<T>() where T : PanelBase
        // {
        //     var panel = TryInitialize<T>($"Common/Panels/{typeof(T).Name}");
        //     
        //     if (panel == null)
        //     {
        //         panel = TryInitialize<T>($"SDK/Panels/{typeof(T).Name}");
        //     }
        //
        //     openedPanels.Add(panel);
        //     return panel;
        // }
        //
        // private T TryInitialize<T>(string path) where T : PanelBase
        // {
        //     var loadedPanel = Resources.Load<T>(path);
        //     if (loadedPanel == null)
        //     {
        //         WraDiagnostics.LogError($"Not found panel at path: {path}", Color.red, LOG_TAG);
        //         return null;
        //     }
        //
        //     var createdPanel = Instantiate(loadedPanel, transform);
        //
        //     WraDiagnostics.LogError($"Spawned panel from: {path}", Color.green, LOG_TAG);
        //
        //     return createdPanel;
        // }
        //
        // private void DestroyPanel(PanelBase panelBase, object dataBase)
        // {
        //     panelBase.SetData(dataBase);
        //     panelBase.OnClose();
        //     openedPanels.Remove(panelBase);
        //     Destroy(panelBase.gameObject);
        // }
    }
}
