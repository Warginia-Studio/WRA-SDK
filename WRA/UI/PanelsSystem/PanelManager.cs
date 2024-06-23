using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using WRA.General.Patterns;
using WRA.General.Patterns.Singletons;
using WRA.UI.PanelsSystem.PanelAnimations;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using WRA.Zenject;
using WRA.Zenject.Panels;
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
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public PanelBase OpenPanel(string panelName, PanelDataBase data = null)
        {
            var panel = GetPanel(panelName);
            if (panel != null)
            {
                panel.SetData(data);
                panel.OnOpen();
                return panel;
            }

            panel = panelFactory.Create(panelName, data);
            if (panel == null)
                return null;
            panel.SetData(data);
            panel.OnOpen();
            openedPanels.Add(panel);
            OnPanelOpen?.Invoke(panel);
            return panel;
        }
        
        public bool ClosePanel(PanelBase panelBase, PanelDataBase data = null)
        {
            return ClosePanel(panelBase.name, data);
        }
        
        public bool ClosePanel(string panelName, PanelDataBase data = null)
        {
            var panel = GetPanel(panelName);
            if (panel == null)
                return false;
            panel.SetData(data);
            panel.OnClose();
            openedPanels.Remove(panel);
            OnPanelClose?.Invoke(panel);
            Destroy(panel.gameObject);
            return true;
        }
        
        public void ShowPanel(string panelName, PanelDataBase panelDataBase = null)
        {
            var panel = GetPanel(panelName);
            if (panel == null)
                return;
            if(panel.GetStatus() == PanelStatus.ShowingAnimation || panel.GetStatus() == PanelStatus.Show)
                return;
            panel.SetData(panelDataBase);
            panel.ShowThisPanel();
        }
        
        public void HidePanel(string panelName, PanelDataBase panelDataBase = null)
        {
            var panel = GetPanel(panelName);
            if (panel == null)
                return;
            if(panel.GetStatus() == PanelStatus.HidingAnimation || panel.GetStatus() == PanelStatus.Hide)
                return;
            panel.SetData(panelDataBase);
            panel.HideThisPanel();
        }
        
        public PanelBase GetPanel(string panelName)
        {
            return openedPanels.Find(panel => panel.name == panelName);
        }
        
        public List<PanelBase> GetPanels()
        {
            return openedPanels;
        }
        
        public bool IsPanelOpened(string panelName)
        {
            return openedPanels.Exists(panel => panel.name == panelName);
        }
    }
}
