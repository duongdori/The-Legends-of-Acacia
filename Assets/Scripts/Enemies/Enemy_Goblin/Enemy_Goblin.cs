using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Goblin : Enemy
{

    #region States

    private GoblinIdleState idleState;
    public GoblinIdleState IdleState => idleState;
    
    private GoblinMoveState moveState;
    public GoblinMoveState MoveState => moveState;
    
    private GoblinBattleState battleState;
    public GoblinBattleState BattleState => battleState;
    
    private GoblinAttackState attackState;
    public GoblinAttackState AttackState => attackState;
    
    private GoblinHurtState hurtState;
    public GoblinHurtState HurtState => hurtState;
    
    private GoblinDeadState deadState;
    public GoblinDeadState DeadState => deadState;
    
    #endregion

    public GameObject bloodEffect;

    
    protected override void Awake()
    {
        base.Awake();
        
        idleState = new GoblinIdleState(this, stateMachine, "idle", enemyData, this);
        moveState = new GoblinMoveState(this, stateMachine, "move", enemyData,this);
        battleState = new GoblinBattleState(this, stateMachine, "move", enemyData,this);
        attackState = new GoblinAttackState(this, stateMachine, "attack", enemyData, this);
        hurtState = new GoblinHurtState(this, stateMachine, "hurt", enemyData, this);
        deadState = new GoblinDeadState(this, stateMachine, "die", enemyData, this);
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
