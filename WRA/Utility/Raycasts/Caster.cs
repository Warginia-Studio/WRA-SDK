using System.Collections.Generic;
using UnityEngine;

namespace WRA.Utility.Raycasts
{
    public abstract class Caster2D
    {
        public class RayData
        {
            public Vector2 start;
            public Vector2 direction;
            public float radius;
            public float range;
            public float currentTime;
            public bool hitted;
            public RaycastHit2D[] hittedObject;

            public RayData(Vector2 s, Vector2 d, float rad, float ran, bool hit, float forTime, params RaycastHit2D[] hits)
            {
                start = s;
                direction = d;
                radius = rad;
                range = ran;
                hitted = hit;
                currentTime = forTime;
                hittedObject = hits;
            
            }
        }

        public Color HittedColor { get; set; } = Color.green;
        public Color NotHittedColor { get; set; } = Color.red;
        public Color HittedObjectColor { get; set; } = Color.yellow;
        public bool ShowHittedObjects { get; set; }
        public float DrawForTime { get; set; } = 1f/60f;
    
        protected List<RayData> rayDatas = new List<RayData>();

        public abstract void Debug();
    
        protected void GenerateData(RaycastHit2D rh)
        {

            if (rh.collider == null)
                return;
        }
    
    }
}
