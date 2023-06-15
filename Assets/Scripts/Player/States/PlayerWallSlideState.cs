using UnityEngine;

public class PlayerWallSlideState : TouchingWallState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerData playerData) : base(player, stateMachine, animBoolName, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlaySFX(5);
    }

    public override void Exit()
    {
        base.Exit();
        AudioManager.Instance.StopSFX(5);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isExitingState)
        {
            player.SetVelocityY(-playerData.wallSlideVelocity);
        }
        
    }
}