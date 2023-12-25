using UnityEngine;

namespace WRA.Utility.Raycasts
{
    [System.Serializable]
    public class CircleCaster2D : Caster2D
    {
        [SerializeField] private float radius;
    
        public override RaycastHit2D Cast()
        {
            var rh = Physics2D.CircleCast(Origin, radius, Direction, distance, masks);
        
            if(drawDebug)
                raycastHitInfos.Add(new RaycastHitInfo<RaycastHit2D>() { RaycastHit2D = rh});

            return rh;
        }

        public override RaycastHit2D[] CastAll()
        {
            var rhAll = Physics2D.CircleCastAll(Origin, radius, Direction, distance, masks);

            if (drawDebug)
            {
                for (int i = 0; i < rhAll.Length; i++)
                {
                    raycastHitInfos.Add(new RaycastHitInfo<RaycastHit2D>(){ RaycastHit2D = rhAll[i]});        
                }
            }
        
            return rhAll;
        }

        public override RaycastHit2D CastWithDepth()
        {
            throw new System.NotImplementedException();
        }

        public override RaycastHit2D[] CastAllWithDepth()
        {
            throw new System.NotImplementedException();
        }

#if UNITY_EDITOR
        protected override void DrawRaycast(RaycastHit2D raycastHit2D, Color usingColor, Vector3 point)
        {
            base.DrawRaycast(raycastHit2D, usingColor, point);

            Gizmos.color = usingColor;
            Gizmos.DrawWireSphere(Origin, radius);
            Gizmos.DrawWireSphere(Origin + point, radius);
        }
#endif
    }
}
