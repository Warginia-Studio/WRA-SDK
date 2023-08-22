using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace WRA.UI.Windows
{
    public class WindowWithTabs : WindowBase
    {
        public UnityEvent<int> OnPageChanged = new UnityEvent<int>();
        public int ActivedPage { get; private set; }

        [SerializeField] private List<GameObject> pages;

        public override void Open(params string[] args)
        {
            var foundArg = args.ToList().Find(ctg => ctg.Contains("Page="));

            var success = int.TryParse(foundArg.Split("=")[1], out int id);
            if (!success)
                return;

            SetActivePage(id);
            // GetType().GetMethods().ToList().Find(ctg => ctg.Name == "XD").Invoke(this, null);
        }

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
