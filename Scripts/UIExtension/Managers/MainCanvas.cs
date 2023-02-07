using Patterns;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UIExtension.Managers
{
    public class MainCanvas : MonoBehaviourSingletonAutoCreate<MainCanvas>
    {
        public Canvas MainCanvasObject { get; private set; }
        private CanvasScaler canvasScaler;
        private void Awake()
        {
            var canvas = GetComponent<Canvas>();
            if (canvas != null)
            {
                MainCanvasObject = canvas;
                return;
            }

            MainCanvasObject = transform.AddComponent<Canvas>();
            canvasScaler = transform.AddComponent<CanvasScaler>();
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        }
    }
}
