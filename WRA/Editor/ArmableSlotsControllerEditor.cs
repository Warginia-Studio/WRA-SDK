using UnityEditor;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.Controls.DD.Controllers;

namespace WRA.Editor
{
    [CustomEditor(typeof(ArmableSlotsController))]
    public class ArmableSlotsControllerEditor : BaseSlotsControllerEditor<ArmamentSlot, ArmableItem>
    {
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
