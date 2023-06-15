using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    #region State Variables

    protected EnemyStateMachine stateMachine;
    public EnemyStateMachine StateMachine => stateMachine;

    #endregion
    
    #region Components

    [SerializeField] protected EnemyData enemyData;
    public EnemyData EnemyData => enemyData;

    public DropItem dropItem;

    #endregion
    
    
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
        
    }

    protected override void Start()
    {
        base.Start();
        
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.CurrentState.LogicUpdate();
    }
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        stateMachine.CurrentState.PhysicsUpdate();
    }

    public override void Die()
    {
        base.Die();
        dropItem.GenerateDrop();
    }

    public void SetColliderHeight(float height)
    {
        Vector2 center = new Vector2(characterCollider.offset.x, -height);
        workspace.Set(characterCollider.size.x, height);

        characterCollider.size = workspace;
        characterCollider.offset = center;
    }

    public virtual RaycastHit2D IsPlayerDetected()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, enemyData.maxDetectedDistance,
            enemyData.whatIsPlayer);
    }
    
    public virtual RaycastHit2D IsPlayerDetectedBack()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * -facingDirection, enemyData.minDetectedDistance,
            enemyData.whatIsPlayer);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawRay(wallCheck.position, new Vector3(enemyData.maxDetectedDistance * facingDirection, 0f));
        Gizmos.DrawRay(wallCheck.position, new Vector3(enemyData.minDetectedDistance * -facingDirection, 0f));
    }

    public virtual void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, enemyData.attackCheckRadius);

        foreach (Collider2D hit in colliders)
        {
            Player playerInfo = hit.GetComponent<Player>();

            if (playerInfo != null)
            {
                stats.DoDamage(playerInfo.Stats);
            }
        }
    }

    public virtual void AnimationTrigger() => stateMachine.CurrentState.AnimationTrigger();
    public virtual void AnimationFinishTrigger() => stateMachine.CurrentState.AnimationFinishTrigger();

    #region Load Components
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyData();
        LoadDropItem();
        baseData = enemyData;
    }
    
    private void LoadEnemyData()
    {
        if(enemyData != null) return;
        enemyData = Resources.Load<EnemyData>("SO/" + gameObject.name + "Data");
        Debug.LogWarning(transform.name + " LoadEnemyData", gameObject);
    }
    
    private void LoadDropItem()
    {
        if(dropItem != null) return;
        dropItem = GetComponent<DropItem>();
        Debug.LogWarning(transform.name + " LoadDropItem", gameObject);
    }

    #endregion
}