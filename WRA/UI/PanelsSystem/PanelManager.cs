using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using WRA.General.Patterns;
using WRA.General.Patterns.Singletons;
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
            if (IsPanelOpened(panelName))
            {
                return GetPanel(panelName);
            }
            return panelFactory.Create(panelName, data);
        }
        
        public PanelBase ClosePanel(string panelName, PanelDataBase data = null)
        {
            if (IsPanelOpened(panelName))
            {
                var panel = GetPanel(panelName);
                panel.SetData(data);
                panel.CloseThisPanel();
                return panel;
            }
            return null;
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
        
        public PanelBase HidePanel(string panelName)
        {
            if (IsPanelOpened(panelName))
            {
                GetPanel(panelName).HideThisPanel();
                return GetPanel(panelName);
            }
            return null;
        }
        
        public PanelBase GetPanel(string panelName)
        {
            return openedPanels.Find(panel => panel.name == panelName);
        }
        
        public bool IsPanelOpened(string panelName)
        {
            return openedPanels.Exists(panel => panel.name == panelName);
        }
    }
}
