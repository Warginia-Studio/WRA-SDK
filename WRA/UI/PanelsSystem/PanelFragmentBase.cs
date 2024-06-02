using UnityEngine;

namespace WRA.UI.PanelsSystem
{
    public abstract class PanelFragmentBase : MonoBehaviour
    {
        public PanelBase ParentPanel { get; set; }

        public void InitFragment(PanelBase panelBase)
        {
            ParentPanel = panelBase;
            OnFragmentInit();
        }

        public virtual void OnFragmentInit() { }
    }
}
