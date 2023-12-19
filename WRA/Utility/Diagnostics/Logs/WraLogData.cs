using UnityEngine;

namespace WRA.Utility.Diagnostics
{
    public class WraLogData : MonoBehaviour
    {
        public WraLogType LogType { get; set; }
        public Color LogColor { get; set; }
        public string Message { get; set; }
        public string RawMessage { get; set; }
        public string LogTag { get; set; }
    }
}
