using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    #region Check Transform

    [SerializeField] private Transform groundCheck;
    public Transform GroundCheck => groundCheck;
    
    [SerializeField] private Transform wallCheck;
    public Transform WallCheck => wallCheck;
    
    [SerializeField] private Transform ledgeCheck;
    public Transform LedgeCheck => ledgeCheck;
    
    [SerializeField] private float groundCheckRadius;
    public float GroundCheckRadius => groundCheckRadius;
    
    [SerializeField] private float wallCheckDistance;
    public float WallCheckDistance => wallCheckDistance;

    [SerializeField] private LayerMask whatIsGround;
    public LayerMask WhatIsGround => whatIsGround;

    #endregion
    
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    public bool CheckIfTouchingWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(wallCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);

        Debug.DrawRay(wallCheck.position, new Vector2(wallCheckDistance, 0f) * core.Movement.FacingDirection, Color.yellow);

        return hit.collider != null;
    }
    
    public bool CheckIfTouchingWallBack()
    {
        RaycastHit2D hit = Physics2D.Raycast(wallCheck.position, Vector2.right * -core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
        
        Debug.DrawRay(wallCheck.position, new Vector2(wallCheckDistance, 0f) * -core.Movement.FacingDirection, Color.red);
        
        return hit.collider != null;
    }

    public bool CheckIfTouchingLedge()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);

        Debug.DrawRay(ledgeCheck.position, new Vector2(wallCheckDistance, 0f) * core.Movement.FacingDirection, Color.blue);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
