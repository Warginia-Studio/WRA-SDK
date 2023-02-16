using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMotorOri : MonoBehaviour
{
    [SerializeField] private float rayForwardDistance = 0.5f;
    [SerializeField] private float rayForwardRadius = 0.3f;
    [SerializeField] private LayerMask wallMask;

    private SphereCaster2D sphereCaster2D = new SphereCaster2D();

    void Update()
    {
        ForwardRay();
    }

    private void OnDrawGizmosSelected()
    {
        sphereCaster2D.Debug();
    }

    private void DrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, 255);
        Gizmos.DrawSphere(Vector2.zero + new Vector2(1,0), 1f);
    }

    public void Move(float direction)
    {
        
    }

    public void Jump()
    {
        
    }

    public void Dash(Vector2 dash)
    {
        
    }

    private void ForwardRay()
    {
        sphereCaster2D.Cast(transform.position, Vector2.right, rayForwardRadius, rayForwardDistance);
    }
}
