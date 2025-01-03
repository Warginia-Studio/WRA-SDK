using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WRA.UI_Extensions.PanelsSystem.PanelAnimations;
using Zenject;

namespace WRA.UI_Extensions.PanelsSystem
{
    public class PanelManager : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<PanelBase> OnPanelOpen, OnPanelShow, OnPanelHide, OnPanelClose;
        
    
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
                return panel;
            }

            panel = panelFactory.Create(panelName, data);
            if (panel == null)
                return null;
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
            openedPanels.Remove(panel);
            OnPanelClose?.Invoke(panel);
            Destroy(panel.gameObject);
            return true;
        }
        
        public bool CloseAllPanels()
        {
            var count = openedPanels.Count;
            for(int i = 0; i < openedPanels.Count; i++)
            {
                ClosePanel(openedPanels[i]);
                i--;
            }
            return count > 0;
        }
        
        public PanelBase ShowPanel(string panelName, PanelDataBase panelDataBase = null)
        {
            var panel = GetPanel(panelName);
            if (panel == null)
                panel = OpenPanel(panelName, panelDataBase);
            // panel.SetData(panelDataBase);
            // panel.OnShow();
            // if(panel.GetStatus() == PanelStatus.ShowingAnimation || panel.GetStatus() == PanelStatus.Show)
                // return panel;
            ShowPanel(panel, panelDataBase);
            return panel;
        }
        
        public void ShowPanel(PanelBase panelBase, PanelDataBase panelDataBase = null)
        {
            panelBase.SetData(panelDataBase);
            panelBase.OnShow();
            OnPanelShow?.Invoke(panelBase);
        }
        
        public PanelBase HidePanel(string panelName, PanelDataBase panelDataBase = null)
        {
            var panel = GetPanel(panelName);
            if (panel == null)
                panel = OpenPanel(panelName, panelDataBase);
            if(panel.GetStatus() == PanelStatus.HidingAnimation || panel.GetStatus() == PanelStatus.Hide)
                return panel;
            HidePanel(panel, panelDataBase);

            return panel;
        }
        
        public void HidePanel(PanelBase panelBase, PanelDataBase panelDataBase = null)
        {
            panelBase.SetData(panelDataBase);
            panelBase.OnHide();
            OnPanelHide?.Invoke(panelBase);
        }
        
        public int HideAllPanels()
        {
            var count = openedPanels.Count;
            openedPanels.ForEach(ctg => HidePanel(ctg));
            return count;
        }
        
        public void UpdatePanel(string panelName, PanelDataBase panelDataBase = null)
        {
            var panel = GetPanel(panelName);
            if (panel == null)
                return;
            panel.SetData(panelDataBase);
        }
        
        public PanelBase GetPanel(string panelName)
        {
            return openedPanels.Find(panel =>
                string.Equals(panel.name, panelName, StringComparison.CurrentCultureIgnoreCase));
        }
        
        public List<PanelBase> GetPanels()
        {
            return openedPanels;
        }
        
        public bool IsPanelOpened(string panelName)
        {
            return openedPanels.Exists(panel => string.Equals(panel.name, panelName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
