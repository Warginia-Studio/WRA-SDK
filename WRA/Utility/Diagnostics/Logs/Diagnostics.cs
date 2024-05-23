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

    public static class Diagnostics
    {
        private static List<LogData> WraLogDatas = new List<LogData>();
        private static List<string> tags = new List<string>() { "all" , "logs", "warnings", "errors", "character" };
        public static UnityEvent<LogData> OnLog = new UnityEvent<LogData>();
        public static UnityEvent<string> OnTagAdded = new UnityEvent<string>();

#if UNITY_EDITOR
        
        [InitializeOnLoadMethod]
        [InitializeOnEnterPlayMode]
        
#endif
        public static void ClearLogs()
        {
            WraLogDatas.Clear();
            
        }
        
        public static void LogFromObject(this Object ob, object message, LogType logType=LogType.log, string logTag = "default")
        {
            Log(message, Color.gray, logTag);
        }
        
        public static void Log(object message, LogType logType=LogType.log, string logTag = "default")
        {
            Log(message, Color.gray, logTag);
        }

        // public static void LogWarning(object message, string logTag = "default")
        // {
        //     LogWarning(message, Color.yellow, logTag);
        // }
        //
        // public static void LogError(object message, string logTag = "default")
        // {
        //     LogError(message, Color.red, logTag);
        // }

        public static void Log(object message, Color color, string logTag ="default")
        {
            AddTag(logTag);
            
            var logData = new LogData() { Message = (string)message, LogType = LogType.log, LogTag = logTag};
            Debug.LogError(logData.GetFinalMessage());
            WraLogDatas.Add(logData);
            OnLog.Invoke(logData);
        }

        public static List<LogData> GetLogsWithTag(string tag = "all")
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
            if (tags.Contains(tag))
                return;

            tags.Add(tag);
            OnTagAdded.Invoke(tag);
        }
    }
}
