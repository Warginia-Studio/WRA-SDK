using UnityEngine;

namespace WRA.Utility.Diagnostics.Logs
{
    public class WraLogData
    {
        public WraLogType LogType { get; set; }
        public Color LogColor { get; set; }
        public string Message { get; set; }
        public string RawMessage { get; set; }
        public string LogTag { get; set; }
    }
}
