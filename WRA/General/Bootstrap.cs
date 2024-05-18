using System;
using UnityEngine;
using WRA.UI.PanelsSystem;
using Zenject;

namespace WRA.General
{
    public class Bootstrap : MonoBehaviour
    {
        public static Bootstrap Instance { get; private set; }
        
        [Inject] private PanelManager panelManager;

        private void Awake()
        {
            if (Instance != null)
                return;
            Instance = this;
        }

        private void Start()
        {
            panelManager.OpenPanel("ProgressPanel");
        }
    }
}
