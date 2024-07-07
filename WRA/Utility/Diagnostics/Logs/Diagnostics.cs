using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using WRA.Utility.Math;
using Object = UnityEngine.Object;

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
        private static List<string> tags = new List<string>() { "all" , "log", "warning", "error", "character", "ok" };
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
            Log(message, logType, logTag, ob);
        }
        
        public static void Log(object message, LogType logType = LogType.log, string logTag ="default")
        {
            Log(message, logType, logTag, null);
        }

        private static void Log(object message, LogType logType, string logTag, Object ob)
        {
            AddTag(logTag);
            
            var logData = new LogData() { Message = (string)message, LogType = logType, LogTag = logTag, Time = GetTime()};
            Debug.Log(logData.GetFinalMessage(), ob);
            WraLogDatas.Add(logData);
            OnLog.Invoke(logData);
        }
        
        public static string GetTime()
        {
            if (Application.isEditor)
                return "";
            return System.DateTime.Now.ToString("[ HH:mm:ss ] ");
        }

        public static List<LogData> GetLogsWithTag(string tag = "all")
        {
            if (tag == "all")
                return WraLogDatas;
            return WraLogDatas.Where(ctg => string.Equals(ctg.LogTag, tag, StringComparison.CurrentCultureIgnoreCase)).ToList();
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
