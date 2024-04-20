using UnityEngine;
using UnityEngine.EventSystems;
using WRA.UI.PanelsSystem;

namespace WRA.Utility.Diagnostics.GameConsole
{
    public class QuickCommandButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private string command;
    
        public void ExecuteCommand()
        {
            PanelManager.Instance.GetPanel<WraGameConsole>().ExecuteCommand(command);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ExecuteCommand();
        }
    }
}
