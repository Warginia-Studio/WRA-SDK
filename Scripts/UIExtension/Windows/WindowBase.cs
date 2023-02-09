using UnityEngine;

namespace UIExtension.Windows
{
    public class WindowBase : MonoBehaviour
    {
        public string WindowName
        {
            get
            {
                if (windowName == null)
                {
                    windowName = gameObject.name;
                }
                return windowName;
            }
        }

        [SerializeField] private string windowName;
        
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
