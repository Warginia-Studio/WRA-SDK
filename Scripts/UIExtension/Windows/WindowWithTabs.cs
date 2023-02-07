using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

namespace UIExtension.Windows
{
    public class WindowWithTabs : MonoBehaviour
    {
        public UnityEvent<int> OnPageChanged = new UnityEvent<int>();
        public int ActivedPage { get; private set; }

        [SerializeField] private List<GameObject> pages;
        
        public void SetActivePage(int id)
        {
            if (ActivedPage >= pages.Count)
                return;
            ResetPages();
            if (id < 0)
            {
                OnPageChanged.Invoke(-1);
                return;
            }
            pages[id].SetActive(true);
            OnPageChanged.Invoke(id);
        }
        
        private void ResetPages()
        {
            for (int i = 0; i < pages.Count; i++)
            {
                pages[i].SetActive(false);
            }
        }
    }
}
