using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using WRA.UI.PanelsSystem.Fragments;
using WRA.UI.PanelsSystem.PanelAnimations;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using Zenject;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.UI.PanelsSystem
{
    [RequireComponent(typeof(CanvasGroup), typeof(PanelActionsFragment))]
    public class PanelBase : MonoBehaviour
    {
        public UnityEvent OnOpenEvent;
        public UnityEvent OnCloseEvent;
        public UnityEvent OnShowEvent;
        public UnityEvent OnHideEvent;
        
        public List<PanelFragmentBase> Fragments => fragments;
        public List<PanelAnimationBase> Animations => animations;
        public PanelManager PanelManager => panelManager;

        public PanelActionsFragment PanelActionsFragment { get; private set; }

        [SerializeField] private bool startAsHide;
        [SerializeField] private bool switchCanvasGroup = true;
        [SerializeField] private List<PanelFragmentBase> fragments = new List<PanelFragmentBase>();
        private List<PanelAnimationBase> animations = new List<PanelAnimationBase>();
        
        [Inject] protected PanelManager panelManager;
        protected CanvasGroup canvasGroup;
        protected object data;

        #region FUNCS_CALLED_FROM_PANEL_MANAGER
        
        public void InitPanelBase(object data = null)
        {
            PanelActionsFragment = GetComponent<PanelActionsFragment>();
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
                if (this.data != null)
                    return;
            }
            this.data = data;
            DataChanged();
        }
        
        public void SetActive(bool active)
        {
            Animations.ForEach(ctg=>ctg.SetVisible(active));
        }

        public PanelStatus GetStatus()
        {
            if (animations == null || animations.Count == 0)
                return GetDefaultStatus();
            return animations.Where(ctg => ctg.UseAnimationFromPanel).Max(ctg => ctg.Status);
        }
        
        /// <summary>
        /// Called once while creating
        /// </summary>
        public virtual void OnCreate()
        {
            OnOpenEvent?.Invoke();
            SetActive(!startAsHide);
        }

        /// <summary>
        /// Called once while destroying
        /// </summary>
        public virtual void OnClose()
        {
            OnCloseEvent?.Invoke();
        }
        
        /// <summary>
        /// Called once while showing
        /// </summary>
        public virtual void OnShow()
        {
            OnShowEvent?.Invoke();
            SetCanvasGroup(true);
            
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

        /// <summary>
        /// Called once while hiding
        /// </summary>
        public virtual void OnHide()
        {
            OnHideEvent?.Invoke();
            SetCanvasGroup(false);
            
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
        
        protected void DataChanged()
        {
            fragments.ForEach(ctg =>
            {
                if(ctg == null)
                    return;
                ctg.OnPanelDataChanged();
            });
        }
        
        private void InitNeededComponents()
        {
            if (canvasGroup == null)
            {
                canvasGroup = GetComponent<CanvasGroup>();
            }
        }
        
        private PanelStatus GetDefaultStatus()
        {
            var alpha = canvasGroup.alpha;
            if (alpha <= 0.1f)
                return PanelStatus.Hide;
            return PanelStatus.Show;
        }

        private void SetCanvasGroup(bool active)
        {
            if (canvasGroup == switchCanvasGroup)
                return;
            canvasGroup.interactable = active;
            canvasGroup.blocksRaycasts = active;
        }
    }
}
