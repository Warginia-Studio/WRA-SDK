using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Caster2D : CasterBase<RaycastHit2D>
{

    
    public float MinDepth
    {
        get => minDepth;
        set => minDepth = value;
    }

    public float MaxDepth
    {
        get => maxDepth;
        set => maxDepth = value;
    }
    
    [SerializeField] protected float minDepth;
    [SerializeField] protected float maxDepth;

#if UNITY_EDITOR
    public override void Debug()
    {
        if (!drawDebug)
            return;

        if (raycastHitInfos == null || raycastHitInfos.Count == 0)
        {
            DrawRaycast(new RaycastHit2D(), NOT_HITTED, Direction * distance);
        }

        for (int i = 0; i < raycastHitInfos.Count; i++)
        {
            var rh = raycastHitInfos[i].RaycastHit2D;
            Color usingColor = NOT_HITTED;
            Vector3 usingPoint = Direction * distance;
            if (rh.collider != null)
            {
                usingColor = HITTED;
                usingPoint = Direction * rh.distance;
            }
            DrawRaycast(rh, usingColor, usingPoint);
        }
        UpdateRaycastAliveTimes();
    }

    protected virtual void DrawRaycast(RaycastHit2D raycastHit2D, Color usingColor, Vector3 point)
    {
        Gizmos.color = usingColor;
        Gizmos.DrawLine(Origin, Origin + point);
        if (!drawHitPoints && raycastHit2D.collider == null)
            return;
        Gizmos.color = OBJECT_HIT_POINT;
        Gizmos.DrawSphere(raycastHit2D.point, OBJECT_HIT_POINT_SIZE);
    }
#endif
}
