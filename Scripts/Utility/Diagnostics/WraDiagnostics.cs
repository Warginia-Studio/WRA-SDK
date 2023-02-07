using UnityEngine;

namespace Utility.Diagnostics
{
    public static class WraDiagnostics
    {
        public static void Log(object message)
        {
            Log(message, Color.white);
        }
    
        public static void Log(object message, Color color)
        {
            int r = (int)(color.r*255);
            int g = (int)(color.g*255);
            int b = (int)(color.b*255);
            int a = (int)(color.a*255);
            string str = "#" + r.ToString("x2") + g.ToString("x2") + b.ToString("x2") + a.ToString("x2");
            string finalMessage = "WRA-SDK LOG: " + message;
            // need upgrade for game
            Debug.Log($"<color={str}>{finalMessage}</color>");
        }
    
        public static void LogWarning(object message)
        {
            LogWarning(message, Color.white);
        }
    
        public static void LogWarning(object message, Color color)
        {
            int r = (int)(color.r*255);
            int g = (int)(color.g*255);
            int b = (int)(color.b*255);
            int a = (int)(color.a*255);
            string str = "#" + r.ToString("x2") + g.ToString("x2") + b.ToString("x2") + a.ToString("x2");
            string finalMessage = "WRA-SDK LOG: " + message;
            // need upgrade for game
            Debug.LogWarning($"<color={str}>{finalMessage}</color>");
        }
    
        public static void LogError(object message)
        {
            LogError(message, Color.white);
        }
    
        public static void LogError(object message, Color color)
        {
            int r = (int)(color.r*255);
            int g = (int)(color.g*255);
            int b = (int)(color.b*255);
            int a = (int)(color.a*255);
            string str = "#" + r.ToString("x2") + g.ToString("x2") + b.ToString("x2") + a.ToString("x2");
            string finalMessage = "WRA-SDK LOG: " + message;
            // need upgrade for game
            Debug.LogError($"<color={str}>{finalMessage}</color>");
        }
    


    }
}
