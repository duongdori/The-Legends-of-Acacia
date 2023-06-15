using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "SO/PlayerData")]
public class PlayerData : BaseData
{
    [Header("Attack Details")]
    public float[] attackMovement;
    public float comboWindow = 0.5f;

    [Header("Jump State")]
    public float jumpVelocity = 20f;
    public int amountOfJumps = 1;

    [Header("Dash State")] 
    public float dashSpeed = 15f;
    public float dashColliderHeight = 1f;
    public float defaultColliderHeight = 2.6f;

    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20f;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1f, 2f);
    
    [Header("In Air State")] 
    public float coyoteTime = 0.2f;

    [Header("Wall Slide State")] 
    public float wallSlideVelocity = 3f;
    
    [Header("Wall Climb State")] 
    public float wallClimbVelocity = 3f;
    
    [Header("Ledge Climb State")] 
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("Dust Effect")] 
    public GameObject landingDust;

}
