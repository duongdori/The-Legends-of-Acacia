using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    #region States

    private SkeletonIdleState idleState;
    public SkeletonIdleState IdleState => idleState;
    
    private SkeletonMoveState moveState;
    public SkeletonMoveState MoveState => moveState;
    
    private SkeletonBattleState battleState;
    public SkeletonBattleState BattleState => battleState;
    
    private SkeletonAttackState attackState;
    public SkeletonAttackState AttackState => attackState;
    
    private SkeletonDeadState deadState;
    public SkeletonDeadState DeadState => deadState;
    
    #endregion

    public GameObject bloodEffect;
    
    protected override void Awake()
    {
        base.Awake();
        
        idleState = new SkeletonIdleState(this, stateMachine, "idle", enemyData, this);
        moveState = new SkeletonMoveState(this, stateMachine, "move", enemyData,this);
        battleState = new SkeletonBattleState(this, stateMachine, "move", enemyData,this);
        attackState = new SkeletonAttackState(this, stateMachine, "attack", enemyData, this);
        deadState = new SkeletonDeadState(this, stateMachine, "die", enemyData, this);
    }

    protected override void Start()
    {
        base.Start();
        
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deadState);
    }

    public void InitializeEffect()
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);

    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
