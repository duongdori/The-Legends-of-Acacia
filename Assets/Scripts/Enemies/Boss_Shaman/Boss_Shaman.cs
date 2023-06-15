using System;
using UnityEngine;

public class Boss_Shaman : Enemy
{
    #region States

    private ShamanIdleState idleState;
    public ShamanIdleState IdleState => idleState;
    
    private ShamanMoveState moveState;
    public ShamanMoveState MoveState => moveState;
    
    private ShamanBattleState battleState;
    public ShamanBattleState BattleState => battleState;
    
    private ShamanAttackState attackState;
    public ShamanAttackState AttackState => attackState;
    
    private ShamanAttack2State attack2State;
    public ShamanAttack2State Attack2State => attack2State;
    
    // private GoblinHurtState hurtState;
    // public GoblinHurtState HurtState => hurtState;
    
    private ShamanDeadState deadState;
    public ShamanDeadState DeadState => deadState;
    
    private ShamanInAirState inAirState;
    public ShamanInAirState InAirState => inAirState;
    
    #endregion

    public GameObject bloodEffect;
    public Transform appearPoint;

    protected override void Awake()
    {
        base.Awake();
        
        idleState = new ShamanIdleState(this, stateMachine, "idle", enemyData, this);
        moveState = new ShamanMoveState(this, stateMachine, "move", enemyData,this);
        battleState = new ShamanBattleState(this, stateMachine, "move", enemyData,this);
        attackState = new ShamanAttackState(this, stateMachine, "attack", enemyData, this);
        attack2State = new ShamanAttack2State(this, stateMachine, "attack", enemyData, this);
        // hurtState = new GoblinHurtState(this, stateMachine, "hurt", enemyData, this);
        deadState = new ShamanDeadState(this, stateMachine, "die", enemyData, this);
        inAirState = new ShamanInAirState(this, stateMachine, "inAir", enemyData, this);
    }

    protected override void Start()
    {
        base.Start();
        transform.position = appearPoint.position;
        facingDirection = -1;
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        if (!IsGroundDetected())
        {
            stateMachine.ChangeState(inAirState);
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
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