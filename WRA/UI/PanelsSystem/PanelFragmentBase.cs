using UnityEngine;

namespace WRA.UI.PanelsSystem
{
    public abstract class PanelFragmentBase : MonoBehaviour
    {
        public PanelBase ParentPanel { get; set; }

        public void InitFragment(PanelBase panelBase)
        {
            ParentPanel = panelBase;
            OnPanelCreated();
        }
        
        public virtual void OnPanelCreated() { }

        public virtual void OnShow() { }
        
        public virtual void OnHide() { }
        
        public virtual void OnClose() { }

        public virtual void OnPanelDataChanged() { }
    }
}
