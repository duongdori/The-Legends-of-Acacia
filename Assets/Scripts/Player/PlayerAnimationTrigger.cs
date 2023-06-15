using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    
    //Call from animation event
    private void AnimationFinishTrigger() => PlayerCtrl.Instance.Player.AnimationFinishTrigger();
    
    //Call from animation event
    private void AnimationTrigger() => PlayerCtrl.Instance.Player.AnimationTrigger();
    
    private void AnimationStopMovementTrigger()
    {
        PlayerCtrl.Instance.Player.PrimaryAttackState.AnimationStopAttackMovementTrigger();
    }
    
    private void AnimationStartMovementTrigger()
    {
        PlayerCtrl.Instance.Player.PrimaryAttackState.AnimationStartAttackMovementTrigger();
    }

    private void AttackTrigger()
    {
        AudioManager.Instance.PlaySFX(0);
        PlayerCtrl.Instance.Player.AttackTrigger();
    }

    private void PlaySFX(int index)
    {
        AudioManager.Instance.PlaySFX(index);
    }
}
