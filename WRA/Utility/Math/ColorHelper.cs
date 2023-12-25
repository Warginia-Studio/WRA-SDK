using UnityEngine;

namespace WRA.Utility.Math
{
    public class ColorHelper
    {
        public static string ColorToHex(Color color)
        {
            int r = (int)(color.r * 255);
            int g = (int)(color.g * 255);
            int b = (int)(color.b * 255);
            int a = (int)(color.a * 255);
            string str = "#" + r.ToString("x2") + g.ToString("x2") + b.ToString("x2") + a.ToString("x2");

            return str;
        }

        public static string GetTextInColor(string message, Color color)
        {
            var hexColor= ColorToHex(color);
        
            return $"<color={hexColor}>{message}</color>";
        }

    }
}
