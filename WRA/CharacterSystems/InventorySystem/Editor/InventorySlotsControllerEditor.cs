using UnityEditor;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.Controls.DD.Controllers;

namespace WRA.CharacterSystems.InventorySystem.Editor
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
