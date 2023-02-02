using System.Collections.Generic;
using Patterns;
using UIExtension.UI;
using UnityEngine;

namespace UIExtension.Managers
{
    [ExecuteInEditMode]
    public class WindowManager : MonoBehaviourSingletonMustExist<WindowManager>
    {
        private int WindowCount;
        private Dictionary<string, Window> allWindows = new Dictionary<string, Window>();

        private List<Window> openedWindows = new List<Window>();
    
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
        
            window.Open(args);
            openedWindows.Add(window);
        }

        public void CloseWindow(string windowName, params string[] args)
        {
            var window = openedWindows.Find(ctg => ctg.WindowName == windowName);

            if (window == null)
            {
                Debug.LogError($"Not found opened {windowName} window");
            }
        
            window.Close(args);
            openedWindows.Remove(window);
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

        public void AddNewWindow(string windowName, Window window)
        {
            allWindows.Add(windowName, window);
            Debug.Log("Added window: " + windowName);
        }

        public void FindAllWindows()
        {
            var windows = FindObjectsOfType<Window>();

            for (int i = 0; i < windows.Length; i++)
            {
                allWindows.Add(windows[i].WindowName, windows[i]);
            }

            WindowCount = allWindows.Count;
        }
    }
}
