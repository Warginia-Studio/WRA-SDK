namespace WRA.UI.PanelsSystem.SubPanels
{
    public class SubViewsPanelData : PanelDataBase
    {
        public int StartPanelId { get; set; }
        public string StartPanelName { get; set; }
        public bool UseId { get; set; }
        public object SubPanelViewData { get; set; }
    }
}
