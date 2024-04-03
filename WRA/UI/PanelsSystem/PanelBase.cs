using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;

namespace WRA.UI.PanelsSystem
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class PanelBase : MonoBehaviour
    {
        public UnityEvent OnOpenEvent;
        public UnityEvent OnCloseEvent;
        public UnityEvent OnShowEvent;
        public UnityEvent OnHideEvent;
        
        public bool IsShow { get; private set; }
        
        public List<PanelFragmentBase> Fragments => fragments;
        public List<PanelAnimationBase> Animations => animations;
        
        [SerializeField] private List<PanelFragmentBase> fragments = new List<PanelFragmentBase>();
        [SerializeField] private List<PanelAnimationBase> animations = new List<PanelAnimationBase>();
        
        protected CanvasGroup canvasGroup;
        protected object data;
        
        #region LAZLY_FUNC
        /// <summary>
        /// These functionsare used to open, close, show, hide panels, from buttons, or other panels.
        /// </summary>
        public void CloseThisPanel()
        {
            PanelManager.Instance.LazlyClose(this);
        }
        
        public void ShowThisPanel()
        {
            IsShow = true;
            OnShow();
        }

        public void HideThisPanel()
        {
            IsShow = false;
            OnHide();
        }
        
        public void SwitchHideThisPanel()
        {
            if (IsShow)
            {
                HideThisPanel();
            }
            else
            {
                ShowThisPanel();
            }
        }
        
        #endregion

        #region FUNCS_CALLED_FROM_PANEL_MANAGER
        
        public void InitPanelBase(object data = null)
        {
            if (data == null)
            {
                WraDiagnostics.LogWarning($"Data is null in {this.GetType().Name}", Color.yellow, "panels");
                data = new PanelDataBase();
            }
            
            SetData(data);
            InitNeededComponents();
            InitFragmentsAndAnimations();
        }
        
        public void SetData(object data)
        {
            if (data == null)
            {
                WraDiagnostics.LogWarning("Data is null", Color.yellow);
                return;
            }

            if (data is not PanelDataBase)
            {
                WraDiagnostics.LogError(
                    $"Data data is type: {data.GetType().FullName} expected {typeof(PanelDataBase).FullName} \n" +
                    System.Environment.StackTrace, Color.red);
                return;
            }

            this.data = data;
        }


        
        public virtual void OnOpen() {}

        public virtual void OnClose() {}

        public virtual void OnShow()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            Animations.ForEach(ctg =>
            {
                if (ctg == null)
                    return;
                ctg.ShowAnimation(null);
            });
        }

        public virtual void OnHide()
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            Animations.ForEach(ctg =>
            {
                if (ctg == null)
                    return;
                ctg.HideAnimation(null);
            });
        }
        
        #endregion
        
        public virtual T GetDataAsType<T>() where T : PanelDataBase
        {
            if (data != null && data is not T)
            {
                WraDiagnostics.LogError($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName} \n" + System.Environment.StackTrace, Color.red);
                throw(new Exception($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName}"));
            }
        
            return data as T;
        }

        protected void SetActive(bool active)
        {
            Animations.ForEach(ctg=>ctg.SetVisible(active));
        }
        
        protected void InitFragmentsAndAnimations()
        {
            // TODO: It can't be like this because it can get fragments from other panel
            // fragments = new List<PanelFragment>(GetComponentsInChildren<PanelFragment>());
            InitFragments();
            InitAnimations();
        }
        
        protected void InitFragments()
        {
            fragments.ForEach(ctg =>
            {
                if(ctg == null)
                    return;
                ctg.SetPanel(this);
                ctg.OnPanelInit();
            });
        }
        
        protected void InitAnimations()
        {
            animations.ForEach(ctg =>
            {
                if (ctg == null)
                    return;
                ctg.SetPanel(this);
                ctg.OnPanelInit();
            });
        }
        
        private void InitNeededComponents()
        {
            if (canvasGroup == null)
            {
                canvasGroup = GetComponent<CanvasGroup>();
            }
        }
        
    }
}
