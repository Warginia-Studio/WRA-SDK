using System;
using System.Collections;
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
        
        [Header("Move Animation")]
        [SerializeField] private bool useMoveAnimation;
        [SerializeField] private float moveAnimationDuration;
        [SerializeField] private Vector3 hidePosition;
        [SerializeField] private Vector3 showPosition;
        
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
            InitFragments();
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
            if (useMoveAnimation)
            {
                StartCoroutine(MoveAnimation(showPosition));
                return;
            }
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public virtual void OnHide()
        {
            if (useMoveAnimation)
            {
                StartCoroutine(MoveAnimation(hidePosition));
                return;
            }
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
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
            if (useMoveAnimation)
            {
                var rectTransform = transform as RectTransform;
                rectTransform.anchoredPosition = active ? showPosition : hidePosition;
                return;
            }
            
            canvasGroup.alpha = active ? 1 : 0;
            canvasGroup.interactable = active;
            canvasGroup.blocksRaycasts = active;
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
        
        private IEnumerator MoveAnimation(Vector3 end)
        {
            float delta = 0;
            var rectTransform = transform as RectTransform;
            var start = rectTransform.anchoredPosition;
            
            while (delta < 1)
            {
                delta += Time.deltaTime / moveAnimationDuration;
                rectTransform.anchoredPosition = Vector3.Lerp(start, end, delta);
                yield return null;
            }
        }
    }
}
