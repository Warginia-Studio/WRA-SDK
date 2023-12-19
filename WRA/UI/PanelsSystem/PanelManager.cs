using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using WRA.General.Patterns;
using WRA.General.Patterns.Singletons;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;

namespace WRA.UI.PanelsSystem
{
    public class PanelManager : MonoBehaviourSingletonMustExist<PanelManager>
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

        public void LazlyClose(PanelBase panelBase)
        {
            DestroyPanel(panelBase, null);
        }
        
        public void LazlyShow(PanelBase panelBase)
        {
            OnPanelShow.Invoke(panelBase);
            panelBase.OnShow(null);
        }
        
        public void LazlyHide(PanelBase panelBase)
        {
            OnPanelHide.Invoke(panelBase);
            panelBase.OnHide(null);
        }
        
        public T OpenPanel<T>(bool startAsHide = false) where T : PanelBase
        {
            return OpenPanel<T, PanelDataBase>(null, startAsHide);
        }
        public T OpenPanel<T, TData>(TData data = null, bool startAsHide = false, PanelBase parrentPanel = null)
            where T : PanelBase where TData : PanelDataBase
        {
            var panel = GetPanel<T>() as T;
            if (panel != null)
            {
                WraDiagnostics.LogWarning($"Panel {typeof(T).FullName} is opened.", LOG_TAG);
                return panel;
            }

            panel = LoadPanelFromResources<T>() as T;
            panel.OnOpen(data);
            if (panel == null)
                return null;
            
            if(parrentPanel!=null)
                panel.transform.SetParent(parrentPanel.transform);
            OnPanelOpen.Invoke(panel);

            if (startAsHide)
            {
                HidePanel<T, TData>(data);
            }
            else
            {
                ShowPanel<T, TData>(data);
            }
            
            return panel;
        }

        public T ShowPanel<T, TData>(TData data, bool openIfIsOff = false) where T : PanelBase where TData : PanelDataBase
        {
            var checkData = IsPanelOpened<T>();

            if (checkData.opened)
            {
                checkData.panel.OnShow(data);
            }
            else if (openIfIsOff)
            {
                return OpenPanel<T, TData>(data);
            }

            OnPanelShow.Invoke(checkData.panel);
            return checkData.panel;
        }

        public T HidePanel<T, TData>(TData data) where T : PanelBase where TData : PanelDataBase
        {
            var checkData = IsPanelOpened<T>();

            if (checkData.opened)
            {
                checkData.panel.OnHide(data);
            }
        
            OnPanelHide.Invoke(checkData.panel);
            return checkData.panel;
        }

        public T GetPanel<T>() where T : PanelBase
        {
            return openedPanels.Find(ctg => ctg is T) as T;
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
        
        private (bool opened, T panel) IsPanelOpened<T>([CallerMemberName]string callerMemberName = "") where T : PanelBase
        {
            var panel = GetPanel<T>() as T;

            if (panel == null)
            {
                WraDiagnostics.LogError($"Panel {typeof(T).FullName} isn't opened. Can't do action {callerMemberName}.", Color.yellow, LOG_TAG);
                return (false, panel);
            }

            return (true, panel);
        }
        
        private T LoadPanelFromResources<T>() where T : PanelBase
        {
            var panel = TryInitialize<T>($"Common/Panels/{typeof(T).Name}");
            
            if (panel == null)
            {
                panel = TryInitialize<T>($"SDK/Panels/{typeof(T).Name}");
            }
        
            openedPanels.Add(panel);
            return panel;
        }

        private T TryInitialize<T>(string path) where T : PanelBase
        {
            var loadedPanel = Resources.Load<T>(path);
            if (loadedPanel == null)
            {
                WraDiagnostics.LogError($"Not found panel at path: {path}", Color.red, LOG_TAG);
                return null;
            }

            var createdPanel = Instantiate(loadedPanel, transform);
        
            WraDiagnostics.LogError($"Spawned panel from: {path}", Color.green, LOG_TAG);

            return createdPanel;
        }

        private void DestroyPanel(PanelBase panelBase, PanelDataBase dataBase)
        {
            panelBase.OnClose(dataBase);
            openedPanels.Remove(panelBase);
            Destroy(panelBase.gameObject);
        }
    }
}
