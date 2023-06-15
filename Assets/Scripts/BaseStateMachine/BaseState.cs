using UnityEngine;

public class BaseState
{
    protected Entity Entity;
    protected BaseStateMachine stateMachine;
    protected Core core;

    #region Animation Variables

    protected bool isAnimationFinished;
    private string animBoolName;

    #endregion
    
    #region Other Variables

    protected bool isExitingState;
    protected float startTime;
    protected float stateTimer;

    #endregion
    
    public BaseState(Entity entity, BaseStateMachine stateMachine, string animBoolName)
    {
        this.Entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        // core = entity.Core;
    }
    
    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
        Entity.Anim.SetBool(animBoolName, true);

    }
    public virtual void Exit()
    {
        isExitingState = true;
        Entity.Anim.SetBool(animBoolName, false);
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