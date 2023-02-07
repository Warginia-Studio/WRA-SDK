using UIExtension.Managers;
using UnityEngine;

namespace UIExtension.UI
{
    public class Window : MonoBehaviour
    {
        public string WindowName => windowName;
        [SerializeField] private string windowName;
        [SerializeField] private bool startAsActive = false;
    
        private void Awake()
        {
            var windowName = this.windowName == null ? gameObject.name : this.windowName;
            WindowManager.Instance.AddNewWindow(windowName, this);
            if (startAsActive)
            {
                WindowManager.Instance.OpenWindow(windowName);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    
        public virtual void Open(params string[] args)
        {
            gameObject.SetActive(true);
        }
    
        public virtual void Close(params string[] args)
        {
            gameObject.SetActive(false);
        }
    }
}
