using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using WRA.UI.PanelsSystem.PanelAnimations;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using Zenject;

namespace WRA.UI.PanelsSystem
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PanelBase : MonoBehaviour
    {
        public UnityEvent OnOpenEvent;
        public UnityEvent OnCloseEvent;
        public UnityEvent OnShowEvent;
        public UnityEvent OnHideEvent;
        
        public bool IsShow { get; private set; }
        
        public List<PanelFragmentBase> Fragments => fragments;
        public List<PanelAnimationBase> Animations => animations;
        
        [SerializeField] private List<PanelFragmentBase> fragments = new List<PanelFragmentBase>();
        [Inject] PanelManager panelManager;
        private List<PanelAnimationBase> animations = new List<PanelAnimationBase>();
        
        protected CanvasGroup canvasGroup;
        protected object data;
        
        #region LAZLY_FUNC
        /// <summary>
        /// These functionsare used to open, close, show, hide panels, from buttons, or other panels.
        /// </summary>
        public void CloseThisPanel()
        {
            // PanelManager.Instance.LazlyClose(this);
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
            SetData(data);
            InitNeededComponents();
            InitFragmentsAndAnimations();
        }
        
        public void SetData(object data)
        {
            if (data is not PanelDataBase)
            {
                WraDiagnostics.LogWarning($"Data is null or is not PanelDataBase in {this.GetType().Name}", Color.yellow, "panels");
                data = new PanelDataBase();
            }
            this.data = data;
        }
        
        public void SetActive(bool active)
        {
            Animations.ForEach(ctg=>ctg.SetVisible(active));
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
        
        public T GetDataAsType<T>() where T : PanelDataBase
        {
            if (data is not T)
            {
                WraDiagnostics.LogError($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName} \n" + System.Environment.StackTrace, Color.red);
                throw(new Exception($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName}"));
            }
        
            return data as T;
        }
        
        protected void InitFragmentsAndAnimations()
        {
            InitFragments();
            var panelAnimations = fragments.FindAll(ctg => ctg is PanelAnimationBase)
                .Select(ctg => ctg as PanelAnimationBase).ToList();
            animations.AddRange(panelAnimations);
        }
        
        protected void InitFragments()
        {
            fragments.ForEach(ctg =>
            {
                if(ctg == null)
                    return;
                ctg.InitFragment(this);
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
