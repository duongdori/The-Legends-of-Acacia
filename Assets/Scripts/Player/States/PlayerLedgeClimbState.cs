using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 detectedPos;
    private Vector2 cornerPos;
    private Vector2 startPos;
    private Vector2 stopPos;
    private Vector2 workspace;

    private bool isHanging;
    private bool isClimbing;


    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerData playerData) : base(player, stateMachine, animBoolName, playerData)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        player.Anim.SetBool("climbLedge", false);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        isHanging = true;
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityZero();
        player.transform.position = detectedPos;
        cornerPos = DetermineCornerPosition();
        
        startPos.Set(cornerPos.x - (playerData.startOffset.x * player.FacingDirection), cornerPos.y - playerData.startOffset.y);
        stopPos.Set(cornerPos.x + (playerData.stopOffset.x * player.FacingDirection), cornerPos.y + playerData.stopOffset.y);

        player.transform.position = startPos;
    }

    public override void Exit()
    {
        base.Exit();

        isHanging = false;

        if (isClimbing)
        {
            player.transform.position = stopPos;
            isClimbing = false;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else
        {
            player.SetVelocityZero();
            player.transform.position = startPos;

            if (xInput == player.FacingDirection && isHanging && !isClimbing)
            {
                isClimbing = true;
                player.Anim.SetBool("climbLedge", true);
            }
            else if (yInput == -1 && isHanging && !isClimbing)
            {
                stateMachine.ChangeState(player.InAirState);
            }
            else if (jumpInput && !isClimbing)
            {
                player.WallJumpState.DetermineWallJumpDirection(true);
                stateMachine.ChangeState(player.WallJumpState);
            }
        }
    }

    public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;

    private Vector2 DetermineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(player.WallCheck.position, Vector2.right * player.FacingDirection,
            player.PlayerData.wallCheckDistance, player.PlayerData.whatIsGround);
        float xDis = xHit.distance;
        workspace.Set((xDis + 0.015f) * player.FacingDirection, 0f);
        
        RaycastHit2D yHit = Physics2D.Raycast(player.LedgeCheck.position + (Vector3)(workspace), Vector2.down,
            player.LedgeCheck.position.y - player.WallCheck.position.y + 0.015f, player.PlayerData.whatIsGround);
        float yDis = yHit.distance;
        
        workspace.Set(player.WallCheck.position.x + (xDis * player.FacingDirection), player.LedgeCheck.position.y - yDis);
        return workspace;
    }
    
}