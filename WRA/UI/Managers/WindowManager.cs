using System.Collections.Generic;
using UnityEngine;
using WRA.General.Patterns;
using WRA.UI.Windows;

namespace WRA.UI.Managers
{
    [ExecuteInEditMode]
    public class WindowManager : MonoBehaviourSingletonAutoCreateUI<WindowManager>
    {
        private int WindowCount;
        private Dictionary<string, WindowBase> allWindows = new Dictionary<string, WindowBase>();

        private List<WindowBase> openedWindows = new List<WindowBase>();

        private void Awake()
        {
            var allWindows = Resources.FindObjectsOfTypeAll<WindowBase>();
            for (int i = 0; i<allWindows.Length; i++)
            {
                this.allWindows.Add(allWindows[i].WindowName, allWindows[i]);
            }
        }

        public void OpenWindow(string windowName, params string[] args)
        {
            var window= allWindows[windowName];
            if (window == null)
            {
                Debug.LogError($"Not found {windowName} window.");
                return;
            }

            if (openedWindows.Find(ctg => ctg == window) != null)
            {
                Debug.LogError($"Window {windowName} is opened.");
                return;
            }

            var newWindow = Instantiate(window.gameObject).GetComponent<WindowBase>();
            newWindow.Open(args);
            openedWindows.Add(newWindow);
        }

        public void CloseWindow(string windowName, params string[] args)
        {
            var window = openedWindows.Find(ctg => ctg.WindowName == windowName);

            if (window == null)
            {
                Debug.LogError($"Not found opened {windowName} window");
                return;
            }
        
            window.Close(args);
            openedWindows.Remove(window);
            Destroy(window.gameObject);
        }

        public void SwitchWindow(string windowName, params string[] args)
        {
            if (openedWindows.Find(ctg => ctg.WindowName == windowName) != null)
            {
                CloseWindow(windowName, args);
                return;
            }
            OpenWindow(windowName, args);
        }
    }
}
