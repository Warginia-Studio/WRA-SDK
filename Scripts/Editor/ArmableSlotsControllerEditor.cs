using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using UIExtension.Controls.DD.Controllers;
using UnityEditor;

namespace Editor
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
