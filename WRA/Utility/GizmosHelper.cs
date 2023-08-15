using UnityEngine;

namespace WRA.Utility
{
    public class GizmosHelper
    {
        public static void DrawArrow2D(Vector2 from, Vector2 to, float arrowAngle = 10f, float arrowLenght = 0.1f)
        {
            Gizmos.DrawLine(from, to);
            var dir = (to - from).normalized;
            var angle = -Mathf.Atan2(dir.x, dir.y) + 90 * Mathf.Deg2Rad;
        
            arrowAngle *= Mathf.Deg2Rad;
            var angleDirLeft = new Vector2(Mathf.Cos(arrowAngle - angle), Mathf.Sin(-arrowAngle + angle));
            var angleDirRight = new Vector2(Mathf.Cos(-arrowAngle - angle), Mathf.Sin(arrowAngle + angle));
        
            Gizmos.DrawLine(to, to - angleDirLeft);
            Gizmos.DrawLine(to, to - angleDirRight);
        }
    }
}
