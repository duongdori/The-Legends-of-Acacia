using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected PlayerData playerData;
    
    #region Animation Variables

    protected bool isAnimationFinished;
    private string animBoolName;

    #endregion
    
    #region Other Variables

    protected bool isExitingState;
    protected float startTime;

    #endregion
    
    protected int xInput;
    protected int yInput;
    
    protected bool jumpInput;
    protected bool dashInput;
    
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected bool isTouchingLedge;
    protected bool isAttacking;


    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerData playerData)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.playerData = playerData;
    }

    public virtual void Enter()
    {
        
        DoChecks();
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
        player.Anim.SetBool(animBoolName, true);
        // Debug.Log(animBoolName);
    }
    public virtual void Exit()
    {
        isExitingState = true;
        player.Anim.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {
        xInput = InputManager.Instance.NormalizeInputX;
        yInput = InputManager.Instance.NormalizeInputY;
        jumpInput = InputManager.Instance.JumpInput;
        dashInput = InputManager.Instance.DashInput;
    }
    
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    protected virtual void DoChecks()
    {
        isGrounded = player.IsGroundDetected();
        isTouchingWall = player.IsWallDetected();
        isTouchingLedge = player.IsLedgeDetected();
        // isAttacking = core.Stats.isAttack;
    }
    public virtual void AnimationTrigger()
    {
        
    }
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
