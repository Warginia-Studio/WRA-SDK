using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SphereCaster2D : Caster2D
{
    public override void Debug()
    {
        for (int i = 0; i < rayDatas.Count; i++)
        {
            DrawSimpleRay(rayDatas[i]);
            rayDatas[i].currentTime -= Time.deltaTime;
            if (rayDatas[i].currentTime <=0)
            {
                rayDatas.RemoveAt(i);
                i--;
            }
        }
    }

    private void DrawSimpleRay(RayData rayData)
    {
        Gizmos.color = rayData.hitted ? HittedColor : NotHittedColor;
        Gizmos.DrawLine(rayData.start, rayData.start+rayData.direction*rayData.range);
        Gizmos.DrawWireSphere(rayData.start, rayData.radius);
        Gizmos.DrawWireSphere(rayData.start+rayData.direction*rayData.range, rayData.radius);

        if (!ShowHittedObjects)
            return;
        Gizmos.color = HittedObjectColor;
        for (int i = 0; i < rayData.hittedObject.Length; i++)
        {
            Gizmos.DrawSphere(rayData.hittedObject[i].point, 0.5f);
        }
    }

    public RaycastHit2D Cast(Vector2 start, Vector2 direction, float radius)
    {
        var rh = Physics2D.CircleCast(start, radius, direction);
        rayDatas.Add(new RayData(start, direction,radius, 1, rh.collider !=null, DrawForTime, rh));
        return rh;
    }
    
    public RaycastHit2D Cast(Vector2 start, Vector2 direction, float radius, float distance)
    {
        var rh = Physics2D.CircleCast(start, radius, direction, distance);
        rayDatas.Add(new RayData(start, direction,radius, distance, rh.collider !=null, DrawForTime, rh));
        return rh;
    }
    
    public RaycastHit2D Cast(Vector2 start, Vector2 direction, float radius, float distance, int layerMask)
    {
        var rh = Physics2D.CircleCast(start, radius, direction, distance, layerMask);
        rayDatas.Add(new RayData(start, direction,radius, distance, rh.collider !=null, DrawForTime, rh));
        return rh;
    }
    
    public RaycastHit2D[] CastAll(Vector2 start, Vector2 direction, float radius)
    {
        var rh = Physics2D.CircleCastAll(start, radius, direction);
        rayDatas.Add(new RayData(start, direction,radius, 1, rh[0].collider !=null, DrawForTime, rh));
        return rh;
    }
    
    public RaycastHit2D[] CastAll(Vector2 start, Vector2 direction, float radius, float distance)
    {
        var rh = Physics2D.CircleCastAll(start, radius, direction, distance);
        rayDatas.Add(new RayData(start, direction,radius, distance, rh[0].collider !=null, DrawForTime, rh));
        return rh;
    }

    public RaycastHit2D[] CastAll(Vector2 start, Vector2 direction, float radius, float distance, int layerMask)
    {
        var rh = Physics2D.CircleCastAll(start, radius, direction, distance, layerMask);
        rayDatas.Add(new RayData(start, direction,radius, distance, rh[0].collider !=null, DrawForTime, rh));
        return rh;
    }

    
}
