using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WRA.UI.PanelsSystem.SubPanels
{
    public class SubViewsPanelBase : PanelBase
    {
        [SerializeField] private List<SubViewBase> allViews = new List<SubViewBase>();

        [SerializeField] private string startPanelName = "";
        
        public void SwitchPanel(string panelName, object data)
        {
            var correctSubPanel = allViews.Find(ctg => ctg.name == panelName);
            OpenSubPanel(correctSubPanel, data);
        }

        public void SwitchPanel(int id, object data)
        {
            var correctSubPanel = allViews[id];
            OpenSubPanel(correctSubPanel, data);
        }

        public override void Open(object data)
        {
            var myData = TryParseData<SubViewsPanelData>(data);
            
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

        public override void Close(object data)
        {
            var myData = TryParseData<SubViewsPanelData>(data);
            if (myData != null)
            {
                
            }
        }

        public override void OnShow(object data)
        {
            
        }

        public override void OnHide(object data)
        {
            
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
            }
            subViewBase.OnShow(data);
        }
    }
}
