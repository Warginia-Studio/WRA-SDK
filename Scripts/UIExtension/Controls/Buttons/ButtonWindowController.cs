using UIExtension.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UIExtension.Controls.Buttons
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
