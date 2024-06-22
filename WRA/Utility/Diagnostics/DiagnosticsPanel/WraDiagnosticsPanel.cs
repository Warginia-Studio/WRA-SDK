using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.Utility.Math;

namespace WRA.Utility.Diagnostics.DiagnosticsPanel
{
    public class WraDiagnosticsPanel : PanelBase
    {
        public class ValueRecord
        {
            public string name;
            public object value;
            public Color color;

            public virtual string ToString()
            {
                return $"{name}: {value}";
            }
        }

        [SerializeField] private DiagnosticFragment fragmentPrefab;
        [SerializeField] private Transform content;
        private List<DiagnosticFragment> records = new List<DiagnosticFragment>();
        
        public void AddRecord(ValueRecord record)
        {
            if (records.Any(ctg => ctg.name == record.name))
            {
                return;
            }
            var fragment = Instantiate(fragmentPrefab, content);
            fragment.SetData(record);
            records.Add(fragment);
        }
        
        public void RemoveRecord(string name)
        {
            records.RemoveAll(ctg => ctg.Record.name == name);
        }
        
        public void RemoveRecord(ValueRecord record)
        {
            records.RemoveAll(ctg => ctg.Record == record);
        }
    }
}
