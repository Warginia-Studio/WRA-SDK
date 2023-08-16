using System.Collections.Generic;
using UnityEngine;

namespace WRA.UI
{
    public class PanelChanger : MonoBehaviour
    {
        [SerializeField] private List<GameObject> allPanels = new List<GameObject>();

        [SerializeField] private string startPanelName = "";

        private void Awake()
        {
            SwitchPanel(startPanelName);
        }

        public void SwitchPanel(string panelName)
        {
            var correctPanel = allPanels.Find(ctg => ctg.name == panelName);
            for (int i = 0; i < allPanels.Count; i++)
            {
                allPanels[i].SetActive(false);
            }
            correctPanel.SetActive(true);
        }
    }
}
