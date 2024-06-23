using WRA.UI.PanelsSystem.PanelAnimations;

namespace WRA.UI.PanelsSystem.Fragments
{
    public class PanelActionsFragment : PanelFragmentBase
    {
        private PanelManager panelManager;
        public override void OnPanelCreated()
        {
            
        }

        public void CloseThisPanel()
        {
            panelManager.ClosePanel(ParentPanel);
        }
        
        public void SwitchHideThisPanel()
        {
            var state = ParentPanel.GetStatus();
            if(state == PanelStatus.Show || state == PanelStatus.ShowingAnimation)
            {
                HideThisPanel();
            }
            else if (state == PanelStatus.Hide || state == PanelStatus.HidingAnimation)
            {
                ShowThisPanel();
            }
        }
    
        public void ShowThisPanel()
        {
            panelManager.ShowPanel(ParentPanel);
        }
    
        public void HideThisPanel()
        {
            panelManager.HidePanel(ParentPanel);
        }
    }
}
