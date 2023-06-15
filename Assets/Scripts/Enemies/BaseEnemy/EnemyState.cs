using UnityEngine;

public class EnemyState
{
    #region Components

    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;
    protected EnemyData enemyData;
    
    #endregion

    private string animBoolName;
    protected float startTime;
    protected float stateTimer;
    protected float lastTimeAttacked;
    protected bool isExitingState;
    protected bool isAnimationFinished;


    
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected bool isTouchingLedge;


    public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyData enemyData)
    {
        this.enemyBase = enemyBase;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.enemyData = enemyData;
    }

    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
        enemyBase.Anim.SetBool(animBoolName, true);

        // Debug.Log(animBoolName);
    }
    public virtual void Exit()
    {
        isExitingState = true;
        enemyBase.Anim.SetBool(animBoolName, false);

    }
    
    public virtual void LogicUpdate()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    protected virtual void DoChecks()
    {
    }
    
    public virtual void AnimationTrigger()
    {
        
    }
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}