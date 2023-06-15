using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    private Rigidbody2D rb;
    public Rigidbody2D RB => rb;

    private Vector2 currentVelocity;
    public Vector2 CurrentVelocity => currentVelocity;
    
    private Vector2 workspace;
    
    private int facingDirection;
    public int FacingDirection => facingDirection;

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponentInParent<Rigidbody2D>();

        facingDirection = 1;
    }

    public void LogicUpdate()
    {
        currentVelocity = rb.velocity;
    }
    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
        currentVelocity = Vector2.zero;
    }
    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, currentVelocity.y);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }
    public void SetVelocityY(float velocity)
    {
        workspace.Set(currentVelocity.x, velocity);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != facingDirection)
        {
            Flip();
        }
    }
    
    public void Flip()
    {
        facingDirection *= -1;
        rb.transform.localScale = new Vector3(facingDirection, 1, 1);
    }
}
