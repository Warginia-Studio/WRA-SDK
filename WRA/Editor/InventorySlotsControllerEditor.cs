using UnityEditor;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.Controls.DD.Controllers;

namespace WRA.Editor
{
    [CustomEditor(typeof(InventorySlotsController))]
    public class InventorySlotsControllerEditor : BaseSlotsControllerEditor<InventorySlot, Item>
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
