using UnityEditor;
using UnityEngine;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.Controls.DD.Controllers;

namespace WRA.CharacterSystems.InventorySystem.Editor
{
    [CustomEditor(typeof(BaseSlotsController<ContainerSlot<ContainerItem>,ContainerItem>))]
    public class BaseSlotsControllerEditor<T1,T2> : UnityEditor.Editor where T1 : ContainerSlot<T2> where T2 : ContainerItem
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var armableSlotsController = ((BaseSlotsController<T1,T2>)target);

            if (armableSlotsController.Dropables == null || armableSlotsController.Dropables.Length == 0)
            {
                EditorGUILayout.HelpBox("No inited slots. Please add slots and init them.", MessageType.Error);
            }
        
            if (GUILayout.Button("Init"))
            {
                armableSlotsController.InitContainer();
            }
        }
    }
}
