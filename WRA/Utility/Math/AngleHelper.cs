using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.Utility.Diagnostics;

public static class AngleHelper
{
    public static float EPSILON = 0.0001f;
    /// <summary>
    /// Base angle is 0 degrees on the right side of the object
    /// </summary>
    /// <param name="position"></param>
    /// <param name="target"></param>
    /// <param name="rangeAngle"></param>
    /// <returns></returns>
    public static bool IsInAngle(Vector2 position, Vector2 target, Vector2 from, float rangeAngle)
    {
        var direction = target - position;
        var angleBetween = Vector2.Angle(from, direction);
        return angleBetween <= rangeAngle+EPSILON;
    }
    
    public static float GetAngle(Vector2 position, Vector2 target)
    {
        var direction = target - position;
        var angleBetween = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angleBetween;
    }
    
    public static Vector2 GetDirection(float angle)
    {
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
    }
}
