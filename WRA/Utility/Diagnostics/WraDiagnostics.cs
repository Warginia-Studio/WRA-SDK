using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using WRA.Utility.Math;

/**********************************************************************
 * Upgrades TODO:
 * Add events and list to generate logs in game
 * Add messages layers + layers configurator with hidding it.
 * Add new console window with layers etc.
 **********************************************************************/

namespace WRA.Utility.Diagnostics
{

    public static class WraDiagnostics
    {
        public static List<WraLogData> WraLogDatas = new List<WraLogData>();
        public static UnityEvent<WraLogData> OnLog = new UnityEvent<WraLogData>();

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
        public static void ClearLogs()
        {
            WraLogDatas.Clear();
        }
#endif
        

        public static void Log(object message)
        {
            Log(message, Color.gray);
        }

        public static void LogWarning(object message)
        {
            LogWarning(message, Color.yellow);
        }

        public static void LogError(object message)
        {
            LogError(message, Color.red);
        }

        public static void Log(object message, Color color)
        {
            string finalMessage = ColorHelper.GetTextInColor("WRA-SDK LOG: " + message, color);
            Debug.Log(finalMessage);

            var logData = new WraLogData() { Message = finalMessage, LogType = WraLogType.log };
            WraLogDatas.Add(logData);
            OnLog.Invoke(logData);
        }

        public static void LogWarning(object message, Color color)
        {
            string finalMessage = ColorHelper.GetTextInColor("WRA-SDK LOG: " + message, color);
            Debug.LogWarning(finalMessage);

            var logData = new WraLogData() { Message = finalMessage, LogType = WraLogType.warning };
            WraLogDatas.Add(logData);
            OnLog.Invoke(logData);
        }

        public static void LogError(object message, Color color)
        {
            string finalMessage = ColorHelper.GetTextInColor("WRA-SDK LOG: " + message, color);
            Debug.LogError(finalMessage);

            var logData = new WraLogData() { Message = finalMessage, LogType = WraLogType.error };
            WraLogDatas.Add(logData);
            OnLog.Invoke(logData);
        }
    }
}
