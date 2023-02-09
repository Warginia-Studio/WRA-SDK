using UIExtension.Managers;
using UIExtension.Windows;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UIExtension.Controls.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ButtonWindowController : MonoBehaviour
    {
        [FormerlySerializedAs("window")] [SerializeField] private WindowBase windowBase;
        [SerializeField] private string args;
    
        public void OpenWindow()
        {
            WindowManager.Instance.OpenWindow(windowBase.WindowName, args);
        }

        public void CloseWindow()
        {
            WindowManager.Instance.CloseWindow(windowBase.WindowName, args);
        }
    }
}
