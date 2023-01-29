using UnityEngine;

namespace UIExtension.Windows
{
    public class WindowWithTabs : MonoBehaviour
    {
        public int ActivedPage { get; private set; }

        [SerializeField] private GameObject[] pages;

        public void SetActivePage(int id)
        {
        
        }

        public void SetActivePage(string name)
        {
        
        }
    }
}
