using UnityEditor;
using UnityEngine;

namespace WRA.UI.TextControl
{
    public class CustomGameObjects
    {
        [MenuItem("GameObject/thief01-SDK/Test", false, 10)]
        public static void CreateCustomGameObject(MenuCommand menuCommand)
        {
            // Create a custom game object
            GameObject go = new GameObject("Custom Game Object");
            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
    }
}
