using UnityEditor;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.Controls.DD.Controllers;

namespace WRA.Editor
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
