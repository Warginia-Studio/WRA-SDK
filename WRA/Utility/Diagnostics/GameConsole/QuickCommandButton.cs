using UnityEngine;
using UnityEngine.EventSystems;
using WRA.UI.PanelsSystem;
using Zenject;

namespace WRA.Utility.Diagnostics.GameConsole
{
    public class QuickCommandButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private string command;
        [Inject] PanelManager panelManager;
    
        public void ExecuteCommand()
        {
            // panelManager.GetPanel<WraGameConsole>().ExecuteCommand(command);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ExecuteCommand();
        }
    }
}
