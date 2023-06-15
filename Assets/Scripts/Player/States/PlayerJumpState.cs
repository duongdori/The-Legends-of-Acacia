using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : AbilityState
{
    private int amountOfJumpsLeft;


    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerData playerData) : base(player, stateMachine, animBoolName, playerData)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlaySFX(2);
        InputManager.Instance.UseJumpInput();
        player.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone = true;
        amountOfJumpsLeft--;
    }

    public bool CanJump()
    {
        return amountOfJumpsLeft > 0;
    }

    public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = playerData.amountOfJumps;

    public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;
}
