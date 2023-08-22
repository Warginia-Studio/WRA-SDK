using UnityEngine;

namespace WRA.Utility
{
    public class ColorToHex
    {
        public static string GetHexColor(Color color)
        {
            int r = (int)(color.r*255);
            int g = (int)(color.g*255);
            int b = (int)(color.b*255);
            int a = (int)(color.a*255);
            string str = "#" + r.ToString("x2") + g.ToString("x2") + b.ToString("x2") + a.ToString("x2");
            return str;
        }
    }
}