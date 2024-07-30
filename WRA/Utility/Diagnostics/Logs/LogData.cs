using System.Collections.Generic;
using UnityEngine;
using WRA.Utility.Math;

namespace WRA.Utility.Diagnostics.Logs
{
    public class LogData
    {
        private readonly List<Color> LOG_COLORS = new List<Color>()
        {
            Color.gray,
            Color.red,
            Color.yellow,
            Color.green,
            Color.red,
            Color.cyan
        }; 
        
        public LogType LogType { get; set; }
        public string Message { get; set; }
        public string LogTag { get; set; }
        public string Time { get; set; }
        public int Count { get; set; } = 1;
        
        public string GetFinalMessage()
        {
            var logType = ColorHelper.GetTextInColor(LogType.ToString().ToUpper(), LOG_COLORS[(int)LogType]);
            if(Count> 1)
                return $"[ {logType} ] [ {Count} ] {Time}{Message}";
            return $"[ {logType} ] {Time}{Message}";
        }
    }
}
