using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "SO/EnemyData")]
public class EnemyData : BaseData
{
    public float moveSpeed = 3f;
    public float moveDetectedSpeed = 5f;

    [Header("Attack Info")]
    public float attackDistance;
    public float attackCooldown;
    public float battleTime;
    
    [Header("Idle State")] 
    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;

    [Header("Detected State")] 
    public float maxDetectedDistance = 8f;
    public float minDetectedDistance = 2f;

    public LayerMask whatIsPlayer;

    [Header("Collider Height")] 
    public float deathColliderHeight = 0.2f;
}