namespace WRA.UI.PanelsSystem
{
    public class PanelDataBase
    {
        // public bool StartAsHide { get; set; }

        public object Data { get; set; }

        public TData GetData<TData>()
        {
            return (TData)Data;
        }
    }
}