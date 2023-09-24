using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WRA.UI.PanelsSystem;

public class PanelManagerEditor
{
    [MenuItem("GameObject/thief01-SDK/PanelManager")]
    public static void CreatePanelManager()
    {
        Canvas canvas = MonoBehaviour.FindObjectOfType<Canvas>();

        
        // Jeśli nie ma Canvasa, tworzymy go
        if (canvas == null)
        {
            GameObject canvasObject = new GameObject("Canvas");
            canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
        }

        EventSystem eventSystem = MonoBehaviour.FindObjectOfType<EventSystem>();

        if (eventSystem == null)
        {
            eventSystem = new GameObject("Event System").AddComponent<EventSystem>();
            eventSystem.GameObject().AddComponent<StandaloneInputModule>();
        }

        
        GameObject g = new GameObject("Panel Manager");
        g.AddComponent<RectTransform>();
        g.AddComponent<PanelManager>();
        g.transform.SetParent(canvas.transform);


        Selection.activeGameObject = g;
        Undo.RegisterCreatedObjectUndo(eventSystem.gameObject, "Create Event system");
        Undo.RegisterCreatedObjectUndo(canvas.gameObject, "Create Canvas");
    }
}
