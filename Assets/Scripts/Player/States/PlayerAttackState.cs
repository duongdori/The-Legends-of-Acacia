using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : AbilityState
{
    private float lastTimeAttacked;
    private int comboCounter;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerData playerData) : base(player, stateMachine, animBoolName, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        if (comboCounter > 2 || Time.time >= lastTimeAttacked + playerData.comboWindow)
        {
            comboCounter = 0;
        }
        
        player.Anim.SetInteger("comboCounter", comboCounter);
    }

    public override void Exit()
    {
        base.Exit();

        player.StartCoroutine(nameof(Player.BusyFor), 0.15f);
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isGrounded && dashInput)
        {
            stateMachine.ChangeState(player.DashState);
        }
    }
    

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isAbilityDone = true;
        InputManager.Instance.UseAttackInput();
    }

    public void AnimationStartAttackMovementTrigger()
    {
        player.SetVelocityX(playerData.attackMovement[comboCounter] * player.FacingDirection);
    }
    
    public void AnimationStopAttackMovementTrigger()
    {
        player.SetVelocityZero();
    }
}
