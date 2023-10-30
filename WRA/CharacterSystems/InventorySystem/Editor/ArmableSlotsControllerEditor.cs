using UnityEditor;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.DragDropSystem.Controllers;

namespace WRA.CharacterSystems.InventorySystem.Editor
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
