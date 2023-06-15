using System.Collections.Generic;
using UnityEngine;

public class BaseData : ScriptableObject
{
    [Header("Health State")]
    public List<float> healthLevels = new List<float>();

    [Header("Move State")]
    public List<float> moveSpeedLevels = new List<float>();
    
    [Header("Other")]
    public float groundCheckRadius;
    public float wallCheckDistance;
    public float attackCheckRadius;

    public LayerMask whatIsGround;
}