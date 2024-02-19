using System;
using System.Collections.Generic;
using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;

namespace WRA.UI.PanelsSystem
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class PanelBase : MonoBehaviour
    {
        public bool IsShow { get; private set; }
        
        [SerializeField] protected List<PanelFragment> fragments = new List<PanelFragment>();
        
        protected CanvasGroup canvasGroup;
        protected object data;
        
        #region LAZLY_FUNC
        /// <summary>
        /// These functionsare used to open, close, show, hide panels, from buttons, or other panels.
        /// </summary>
        public virtual void CloseThisPanel()
        {
            PanelManager.Instance.LazlyClose(this);
        }
        
        public virtual void ShowThisPanel()
        {
            IsShow = true;
            PanelManager.Instance.LazlyShow(this);
        }

        public virtual void HideThisPanel()
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

        public void InitPanelBase(object data = null)
        {
            SetData(data);
            InitNeededComponents();
            InitFragments();
        }
        
        public void SetData(object data)
        {
            if (data!= null && data is PanelDataBase)
            {
                this.data = data;   
            }
            else
            {
                WraDiagnostics.LogError(
                    $"Data data is type: {data.GetType().FullName} expected {typeof(PanelDataBase).FullName} \n" +
                    System.Environment.StackTrace, Color.red);
            }
        }

        
        public virtual void OnOpen() {}

        public virtual void OnClose() {}

        public virtual void OnShow()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public virtual void OnHide()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        
        protected virtual T GetDataAsType<T>() where T : PanelDataBase
        {
            if (data != null && data is not T)
            {
                WraDiagnostics.LogError($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName} \n" + System.Environment.StackTrace, Color.red);
                throw(new Exception($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName}"));
            }
        
            return (T)data;
        }
        
        private void InitNeededComponents()
        {
            if (canvasGroup == null)
            {
                canvasGroup = GetComponent<CanvasGroup>();
            }
        }

        private void InitFragments()
        {
            // TODO: It can't be like this because it can get fragments from other panel
            // fragments = new List<PanelFragment>(GetComponentsInChildren<PanelFragment>());
            fragments.ForEach(ctg =>
            {
                ctg.SetPanel(this);
                ctg.OnPanelInit();
            });
        }
    }
}
