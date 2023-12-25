using System.Collections.Generic;
using UnityEngine;

namespace WRA.Utility.Raycasts
{
    [System.Serializable]
    public abstract class CasterBase<T>
    {
        protected readonly Color NOT_HITTED = Color.red;
        protected readonly Color HITTED = Color.green;
        protected readonly Color OBJECT_HIT_POINT = Color.yellow;
        protected readonly float OBJECT_HIT_POINT_SIZE = 0.1f;

        public Vector3 Origin { get; set; }
        public Vector3 Direction { get; set; }
    
        public Transform ObjectOrigin { get; set; }
    
        public LayerMask Masks
        {
            get => masks;
            set => masks = value;
        }

        public float Distance
        {
            get => distance;
            set => distance = value;
        }

#if UNITY_EDITOR
        [Header("Raycast debug settings: ")]
        [Tooltip("If less or equal 0, then it show at least one frame.")]
        [SerializeField] protected float hitInfoLife;
        [Tooltip("Debug raycast")]
        [SerializeField] protected bool drawDebug;
        [Tooltip("Debug hitted point.")]
        [SerializeField] protected bool drawHitPoints;

        [SerializeField] private bool drawOnlyLastInstance = true;
#endif
    
        [Header("Raycast settings")]
        [SerializeField] protected LayerMask masks;
        [SerializeField] protected float distance;

        protected List<RaycastHitInfo<T>> raycastHitInfos = new List<RaycastHitInfo<T>>();


        public abstract T Cast();

        public abstract T[] CastAll();

        public abstract T CastWithDepth();

        public abstract T[] CastAllWithDepth();

#if UNITY_EDITOR
        /// <summary>
        /// Call in gizmos fucntions only.
        /// </summary>
        public abstract void Debug();
#endif

        protected void UpdateRaycastAliveTimes()
        {
            if (hitInfoLife > 0 && drawOnlyLastInstance)
            {
                for (int i = 0; i < raycastHitInfos.Count-1; i++)
                {
                    raycastHitInfos[i].AliveTime = hitInfoLife + 1;
                }
            }
        
            for (int i = 0; i < raycastHitInfos.Count; i++)
            {
                if (raycastHitInfos[i].AliveTime > hitInfoLife)
                {
                    raycastHitInfos.RemoveAt(i);
                    i--;
                    continue;
                }

                raycastHitInfos[i].AliveTime += Time.deltaTime;
            }
        }
    }
}
