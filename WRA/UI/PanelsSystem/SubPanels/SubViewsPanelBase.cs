using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WRA.UI.PanelsSystem.SubPanels
{
    public class SubViewsPanelBase : PanelBase
    {
        public int CurrentViewId { get; private set; }
        public SubViewBase CurrentViewData { get; private set; }
        
        [SerializeField] private List<SubViewBase> allViews = new List<SubViewBase>();

        [SerializeField] private string startPanelName = "";
        [SerializeField] private bool loopIndex = false;

        public void Next()
        {
            SwitchPanel(CurrentViewId+1);
        }

        public void Previous()
        {
            SwitchPanel(CurrentViewId-1);   
        }

        public void SwitchPanel(string panelName)
        {
            SwitchPanel(panelName, null);
        }

        public void SwitchPanel(int id)
        {
            SwitchPanel(id, null);
        }
        public void SwitchPanel(string panelName, object data)
        {
            var correctSubPanel = allViews.Find(ctg => ctg.name == panelName);
            OpenSubPanel(correctSubPanel, data);
        }

        public void SwitchPanel(int id, object data)
        {
            id = CheckIndex(id);
            var correctSubPanel = allViews[id];
            OpenSubPanel(correctSubPanel, data);
        }

        public override void OnCreate()
        {
            var myData = GetDataAsType<SubViewsPanelData>();
            
            if (myData != null)
            {
                if (myData.UseId)
                {
                    SwitchPanel(myData.StartPanelId, myData.SubPanelViewData);
                }
                else
                {
                    SwitchPanel(myData.StartPanelName, myData.SubPanelViewData);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(startPanelName))
                {
                    SwitchPanel(0, null);
                }
                else
                {
                    SwitchPanel(startPanelName, null);
                }
            }
        }

        private int CheckIndex(int id)
        {
            if (id > allViews.Count)
            {
                id = loopIndex ? 0 : allViews.Count - 1;
            }

            if (id < 0)
            {
                id = loopIndex ? allViews.Count - 1 : 0;
            }

            return id;
        }
        
        private void TryGetViews()
        {
            if (allViews != null && allViews.Count > 0)
                return;

            allViews = GetComponentsInChildren<SubViewBase>().ToList();
        }

        private void OpenSubPanel(SubViewBase subViewBase, object data)
        {
            for (int i = 0; i < allViews.Count; i++)
            {
                if (allViews[i] != subViewBase)
                {
                    allViews[i].OnHide();
                    allViews[i].gameObject.SetActive(false);
                }
                else
                {
                    CurrentViewId = i;
                }
            }
            
            subViewBase.OnShow(data);
            subViewBase.gameObject.SetActive(true);
            
            CurrentViewData = subViewBase;
        }
    }
}
