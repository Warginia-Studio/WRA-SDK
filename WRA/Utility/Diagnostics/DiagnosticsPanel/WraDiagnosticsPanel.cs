using System.Collections.Generic;
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
            public object value;
            public Color color;
        }
        private TMP_Text text;

        private string message = "";
        private Dictionary<string, ValueRecord> values = new Dictionary<string, ValueRecord>();

        private void Awake()
        {
            text = GetComponentInChildren<TMP_Text>();
        }

        private void Update()
        {
            UpdateMessage();
        }

        public override void OnOpen()
        {
            message = "NO DATA";
        }

        public override void OnShow()
        {
            canvasGroup.alpha = 1;
        }

        public void AddNewValue(string name, object newValue)
        {
            AddNewValue(name, newValue, Color.gray);
        }
    
        public void AddNewValue(string name, object newValue, Color color)
        {
            values.Add(name, new ValueRecord(){value = newValue, color = color});
        }
        
        public void AddNewValue(string name, ValueRecord valueRecord)
        {
            values.Add(name, valueRecord);
        }

        public void UpdateValue(string name, object newValue)
        {
            if(!values.ContainsKey(name))
                AddNewValue(name, newValue);
            values[name].value = newValue;
        }
    
        public void UpdateColor(string name, Color color)
        {
            if(!values.ContainsKey(name))
                return;
            values[name].color = color;
        }
    
        public void RemoveValue(string name)
        {
            values.Remove(name);
        }

        private void UpdateMessage()
        {
            if(values.Count == 0)
                return;
            message = "";
            foreach (var value in values)
            {
                message += ColorHelper.GetTextInColor($"{value.Key}: {value.Value.value}\n", value.Value.color);
            }
            text.text = message;
        }
    }
}
