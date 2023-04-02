using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using UIExtension.Controls.DD.Controllers;
using UnityEditor;

namespace Editor
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
