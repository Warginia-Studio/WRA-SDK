using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using UIExtension.Controls.DD.Controllers;
using UnityEditor;

namespace Editor
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
