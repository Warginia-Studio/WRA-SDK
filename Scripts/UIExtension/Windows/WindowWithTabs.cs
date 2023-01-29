using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UIExtension.UI.Buttons;
using UnityEngine.Events;

namespace UIExtension.Windows
{
    public class WindowWithTabs : MonoBehaviour
    {
        public UnityEvent<int> OnPageChanged = new UnityEvent<int>();
        public int ActivedPage { get; private set; }

        [SerializeField] private List<GameObject> pages;
        [SerializeField] private ButtonTrigger[] triggeredButtons;

        private void Start()
        {
            SetActivePage(0);
        }

        public void SetActivePage(int id)
        {
            if (ActivedPage >= pages.Count)
                return;
            ResetPages();
            pages[id].SetActive(true);
            ResetTriggeredButtons(id);
            OnPageChanged.Invoke(id);
        }

        public void SetActivePage(string name)
        {
            var page = pages.Find(ctg => ctg.name == name);
            if (pages == null)
                return;
            ResetPages();
            page.SetActive(true);
            var id = pages.IndexOf(page);
            OnPageChanged.Invoke(id);
            ResetTriggeredButtons(id);
        }
        
        private void ResetTriggeredButtons(int laeveAsActive)
        {
            for (int i = 0; i < triggeredButtons.Length; i++)
            {
                if (i == laeveAsActive)
                {
                    triggeredButtons[i].SetStatus(true);
                    continue;
                }
                triggeredButtons[i].SetStatus(false);
            }
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
