using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using WRA.Utility.Math;

/**********************************************************************
 * Upgrades TODO:
 * Add events and list to generate logs in game
 * Add new console window with layers etc.
 * Add better log file
 **********************************************************************/

namespace WRA.Utility.Diagnostics.Logs
{

    public static class WraDiagnostics
    {
        private static List<WraLogData> WraLogDatas = new List<WraLogData>();
        private static List<string> tags = new List<string>() { "all" , "logs", "warnings", "errors", "character" };
        public static UnityEvent<WraLogData> OnLog = new UnityEvent<WraLogData>();
        public static UnityEvent<string> OnTagAdded = new UnityEvent<string>();
        
        [InitializeOnLoadMethod]
        [InitializeOnEnterPlayMode]
        public static void ClearLogs()
        {
            WraLogDatas.Clear();
        }
        
        public static void Log(object message, string logTag = "default")
        {
            Log(message, Color.gray, logTag);

        }

        public static void LogWarning(object message, string logTag = "default")
        {
            LogWarning(message, Color.yellow, logTag);
        }

        public static void LogError(object message, string logTag = "default")
        {
            LogError(message, Color.red, logTag);
        }

        public static void Log(object message, Color color, string logTag ="default")
        {
            AddTag(logTag);
            string finalMessage = ColorHelper.GetTextInColor("WRA-SDK LOG: " + message, color);
            Debug.Log(finalMessage);

            var logData = new WraLogData() { RawMessage = (string)message, Message = finalMessage, LogType = WraLogType.log, LogTag = logTag, LogColor = color};
            WraLogDatas.Add(logData);
            OnLog.Invoke(logData);
        }

        public static void LogWarning(object message, Color color, string logTag = "default")
        {
            AddTag(logTag);
            string finalMessage = ColorHelper.GetTextInColor("WRA-SDK LOG: " + message, color);
            Debug.LogWarning(finalMessage);

            var logData = new WraLogData() { RawMessage = (string)message, Message = finalMessage, LogType = WraLogType.warning , LogTag = logTag, LogColor = color};
            WraLogDatas.Add(logData);
            OnLog.Invoke(logData);
        }

        public static void LogError(object message, Color color, string logTag = "default")
        {
            AddTag(logTag);
            string finalMessage = ColorHelper.GetTextInColor("WRA-SDK LOG: " + message, color);
            Debug.LogError(finalMessage);

            var logData = new WraLogData() { RawMessage = (string)message, Message = finalMessage, LogType = WraLogType.error, LogTag = logTag, LogColor = color};
            WraLogDatas.Add(logData);
            OnLog.Invoke(logData);
        }

        public static List<WraLogData> GetLogsWithTag(string tag = "all")
        {
            if (tag == "all")
                return WraLogDatas;
            return WraLogDatas.Where(ctg => ctg.LogTag == tag).ToList();
        }

        public static List<string> GetTags()
        {
            return tags;
        }
        
        private static void AddTag(string tag)
        {
            if (!tags.Contains(tag))
            {
                tags.Add(tag);
                OnTagAdded.Invoke(tag);
            }
        }
    }
}
