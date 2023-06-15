using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerData playerData) : base(player, stateMachine, animBoolName, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // AudioManager.Instance.PlaySFX(1);
    }

    public override void Exit()
    {
        base.Exit();
        // AudioManager.Instance.StopSFX(1);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        player.CheckIfShouldFlip(xInput);
        
        if (isExitingState) return;

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.SetVelocityX(player.Stats.moveSpeed.GetValue() * xInput);
    }

    protected override void DoChecks()
    {
        base.DoChecks();
    }
}
