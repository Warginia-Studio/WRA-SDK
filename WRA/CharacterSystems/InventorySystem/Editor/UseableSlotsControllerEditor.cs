using UnityEditor;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.Controls.DD.Controllers;

namespace WRA.CharacterSystems.InventorySystem.Editor
{
    [CustomEditor(typeof(UseableSlotsController))]
    public class UseableSlotsControllerEditor : BaseSlotsControllerEditor<ContainerSlot<ContainerItem>, ContainerItem>
    {
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
