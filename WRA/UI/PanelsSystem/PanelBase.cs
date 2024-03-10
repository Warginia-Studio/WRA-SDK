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
        
        [Obsolete("Use for animation use PanelAnimationBase instead")]
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
            PanelManager.Instance.LazlyShow(this);
        }

        public void HideThisPanel()
        {
            IsShow = false;
            PanelManager.Instance.LazlyHide(this);
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
            Animations.ForEach(ctg => ctg.ShowAnimation(null));
        }

        public virtual void OnHide()
        {
            Animations.ForEach(ctg => ctg.HideAnimation(null));
        }
        
        #endregion
        
        public virtual T GetDataAsType<T>() where T : PanelDataBase
        {
            if (data != null && data is not T)
            {
                WraDiagnostics.LogError($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName} \n" + System.Environment.StackTrace, Color.red);
                throw(new Exception($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName}"));
            }
        
            return (T)data;
        }

        protected void SetActive(bool active)
        {
            Animations.ForEach(ctg=>ctg.SetVisible(active));
        }
        
        private void InitNeededComponents()
        {
            if (canvasGroup == null)
            {
                canvasGroup = GetComponent<CanvasGroup>();
            }
        }

        private void InitFragmentsAndAnimations()
        {
            // TODO: It can't be like this because it can get fragments from other panel
            // fragments = new List<PanelFragment>(GetComponentsInChildren<PanelFragment>());
            fragments.ForEach(ctg =>
            {
                if(ctg == null)
                    return;
                ctg.SetPanel(this);
                ctg.OnPanelInit();
            });
            
            animations.ForEach(ctg =>
            {
                if (ctg == null)
                    return;
                ctg.SetPanel(this);
                ctg.OnPanelInit();
            });
        }
    }
}
