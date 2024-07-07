using TMPro;
using UnityEngine;

namespace WRA.Utility.Diagnostics.DiagnosticsPanel
{
    public class DiagnosticFragment : MonoBehaviour
    {
        public WraDiagnosticsPanel.ValueRecord Record { get; set; }
        [SerializeField] private TextMeshProUGUI label;
        [SerializeField] private TextMeshProUGUI value;
    
        private void Update()
        {
            if (Record == null)
                return;
            value.text = Record.value.ToString();
            value.color = Record.color;
        }

        public void SetData(WraDiagnosticsPanel.ValueRecord record)
        {
            label.text = record.name + ": ";
            Record = record;
        }
    }
}
