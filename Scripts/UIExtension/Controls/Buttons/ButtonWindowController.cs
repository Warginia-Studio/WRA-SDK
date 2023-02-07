using UnityEngine;
using UnityEngine.UI;
using WRACore.UIExtension.Managers;

namespace WRACore.UIExtension.Controls.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ButtonWindowController : MonoBehaviour
    {
        [SerializeField] private Window window;
        [SerializeField] private string args;
    
        public void OpenWindow()
        {
            WindowManager.Instance.OpenWindow(window.WindowName, args);
        }

        public void CloseWindow()
        {
            WindowManager.Instance.CloseWindow(window.WindowName, args);
        }
    }
}
