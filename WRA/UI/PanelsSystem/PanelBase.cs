using System;
using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;

namespace WRA.UI.PanelsSystem
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class PanelBase : MonoBehaviour
    {
        public bool IsShow { get; private set; }
        
        private CanvasGroup canvasGroup;
        
        protected virtual void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        
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
        
        public virtual void OnOpen(object data) {}

        public virtual void OnClose(object data) {}

        public virtual void OnShow(object data)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public virtual void OnHide(object data)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        
        protected virtual T TryParseData<T>(object data) where T : PanelDataBase
        {
            if (data != null && data is not T)
            {
                WraDiagnostics.LogError($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName} \n" + System.Environment.StackTrace, Color.red);
                throw(new Exception($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName}"));
            }
        
            return (T)data;
        }
    }
}
