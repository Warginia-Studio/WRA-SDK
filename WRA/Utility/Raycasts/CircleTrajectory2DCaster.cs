using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace WRA.Utility.Raycasts
{
    [System.Serializable]
    public class CircleTrajectory2DCaster
    {
        public struct PredictedData
        {
            public Vector3 realPosition;
            public Vector3 offset;
            public Vector3 velocity;
            public Collider2D collider;
        }
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

        public float Radius => radius;
        
        public List<PredictedData> PredictedDatas { get; private set; } = new List<PredictedData>();

        [SerializeField] private float radius = 1;
        [SerializeField] private int frames = 10;
        [SerializeField] private LayerMask masks;
        
        [Header("Debug")]
        [SerializeField] private bool debug = false;
        [SerializeField] private bool drawVelocity = false;

        public List<PredictedData> CalculateTracjetory()
        {
            return CalculateTracjetory(Rigidbody2D.position, Rigidbody2D.velocity, Rigidbody2D.drag);
        }

        public List<PredictedData> CalculateTracjetory(Vector2 startPosition, Vector2 startVelocity, float drag)
        {
            List<PredictedData>predictedDatas = new List<PredictedData>();
            
            Vector2 velocity = startVelocity;
            Vector2 currentPosition = Vector3.zero;

            for (int i = 0; i < Frames; i++)
            {
                var collider = Physics2D.OverlapCircle(startPosition + currentPosition, radius, Masks);
                
                predictedDatas.Add(new PredictedData()
                {
                    realPosition = startPosition + currentPosition,
                    offset = currentPosition,
                    velocity = velocity,
                    collider = collider
                });
                
                if (collider != null)
                {
                    break;
                }
                
                currentPosition += velocity * TIME_STEP;
                velocity += Physics2D.gravity * TIME_STEP;
                velocity -= velocity * drag;
            }

            PredictedDatas = predictedDatas;
            
            return predictedDatas;
        }
        
#if UNITY_EDITOR
        public void Debug()
        {
            for (int i = 0; i < PredictedDatas.Count; i++)
            {
                if(debug)
                    DrawPosition(PredictedDatas[i]);
                if(drawVelocity)
                    DrawVelocity(PredictedDatas[i]);
            }
            
        }
        
        private void DrawPosition(PredictedData data)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(data.realPosition, radius);
        }

        private void DrawVelocity(PredictedData data)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(data.realPosition, data.realPosition + data.velocity.normalized);
        }
#endif
    }
}