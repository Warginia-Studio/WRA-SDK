using System.Collections.Generic;
using UnityEngine;

namespace WRA.Utility
{
    public class Trajectory2DHelper
    {
        private const float TIME_STEP = 1f / 60f;
        private const float COLLIDER_CHECK = 0.1f;
        public static Vector3[] CalculateTracjetory(Rigidbody2D rigidbody2D, int frames, int layers)
        {
            return CalculaceTrajctory(rigidbody2D, rigidbody2D.velocity, frames, layers);
        }

        public static Vector3[] CalculaceTrajctory(Rigidbody2D rigidbody2D, Vector2 startCustomVelocity, int frames, int layers)
        {
            List<Vector3> points = new List<Vector3>();
            Vector2 velocity = startCustomVelocity;
            Vector2 currentPosition = Vector3.zero;
            points.Add(currentPosition);
            
            for (int i = 0; i < frames; i++)
            {
                currentPosition += velocity * TIME_STEP;
                points.Add(currentPosition);    
                velocity += Physics2D.gravity * TIME_STEP;
                velocity -= velocity * rigidbody2D.drag;
                if (Physics2D.OverlapCircle(rigidbody2D.position + currentPosition, COLLIDER_CHECK, layers) != null)
                {
                    break;
                }
            }
            
            return points.ToArray();
        }
    }
}