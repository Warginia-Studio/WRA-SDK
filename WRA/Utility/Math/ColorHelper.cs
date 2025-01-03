using Unity.VisualScripting;
using UnityEngine;

namespace WRA.Utility.Math
{
    public class ColorHelper
    {
        public static string GetTextInColor(string message, Color color)
        {
            var hexColor= color.ToHexString();
            return $"<color=#{hexColor}>{message}</color>";
        }

    }
}
