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
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

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
        public PanelManager PanelManager => panelManager;
        
        [SerializeField] private List<PanelFragmentBase> fragments = new List<PanelFragmentBase>();
        private List<PanelAnimationBase> animations = new List<PanelAnimationBase>();
        
        [Inject] protected PanelManager panelManager;
        protected CanvasGroup canvasGroup;
        protected object data;
        
        #region LAZLY_FUNC

        public void CloseThisPanel()
        {
            panelManager.ClosePanel(this);
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
                this.LogFromObject($"Data is null or is not PanelDataBase in {this.GetType().Name}", LogType.warning, "panels");
                data = new PanelDataBase();
            }
            this.data = data;
        }
        
        public void SetActive(bool active)
        {
            Animations.ForEach(ctg=>ctg.SetVisible(active));
        }

        public PanelAnimationStatus GetStatus()
        {
            if(animations == null || animations.Count == 0)
                return PanelAnimationStatus.None;
            return animations.Where(ctg => ctg.UseAnimationFromPanel).Max(ctg => ctg.Status);
        }
        
        public bool IsAnimationPlaying()
        {
            var isAnimating = animations.Any(ctg =>
                ctg.Status == PanelAnimationStatus.ShowingAnimation ||
                ctg.Status == PanelAnimationStatus.HidingAnimation);
            return isAnimating;
        }

        public virtual void OnOpen()
        {
            OnOpenEvent?.Invoke();
        }

        public virtual void OnClose()
        {
            OnCloseEvent?.Invoke();
        }

        public virtual void OnShow()
        {
            OnShowEvent?.Invoke();
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            
            if (Animations == null || Animations.Count == 0)
            {
                canvasGroup.alpha = 1;
                return;
            }

            Animations.ForEach(ctg =>
            {
                if (ctg == null)
                    return;
                if(!ctg.UseAnimationFromPanel)
                    return;
                ctg.ShowAnimation(null);
            });
        }

        public virtual void OnHide()
        {
            OnHideEvent?.Invoke();
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            
            if (Animations == null || Animations.Count == 0)
            {
                canvasGroup.alpha = 0;
                return;
            }
            
            Animations.ForEach(ctg =>
            {
                if (ctg == null)
                    return;
                if(!ctg.UseAnimationFromPanel)
                    return;
                ctg.HideAnimation(null);
            });
        }
        
        #endregion
        
        public T GetDataAsType<T>() where T : PanelDataBase
        {
            if (data is not T)
            {
                this.LogFromObject($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName}", LogType.error, "panels");
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
