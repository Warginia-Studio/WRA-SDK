using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace WRA.Utility
{
    [System.Serializable]
    public class CircleTrajectory2DCaster
    {
        private const float TIME_STEP = 1f / 60f;
        public Rigidbody2D Rigidbody2D { get; set; }

        public int Frames
        {
            get => frames;
            set => frames = value;
        }

        public LayerMask Masks
        {
            get => masks;
            set => masks = value;
        }

        public List<Vector3> Trajectory { get; set; } = new List<Vector3>();

        [SerializeField] private float radius = 1;
        [SerializeField] private int frames = 10;
        [SerializeField] private LayerMask masks;

        public List<Vector3> CalculateTracjetory()
        {
            return CalculateTracjetory(Rigidbody2D.position, Rigidbody2D.velocity, Rigidbody2D.drag);
        }

        public List<Vector3> CalculateTracjetory(Vector2 startPosition, Vector2 startVelocity, float drag)
        {
            List<Vector3> points = new List<Vector3>();
            Vector2 velocity = startVelocity;
            Vector2 currentPosition = Vector3.zero;
            points.Add(currentPosition);
            
            for (int i = 0; i < Frames; i++)
            {
                currentPosition += velocity * TIME_STEP;
                points.Add(currentPosition);    
                velocity += Physics2D.gravity * TIME_STEP;
                velocity -= velocity * drag;
                if (Physics2D.OverlapCircle(startPosition + currentPosition, radius, Masks) != null)
                {
                    break;
                }
            }

            Trajectory = points;
            
            return points;
        }
        
#if UNITY_EDITOR
        public void Debug()
        {
            for (int i = 0; i < Trajectory.Count; i++)
            {
                Gizmos.DrawSphere(Rigidbody2D.transform.position + Trajectory[i], radius);
            }
            
        }
#endif
    }
}