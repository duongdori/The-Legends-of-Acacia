using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    // [SerializeField] protected Animator baseAnimator;
    [SerializeField] protected Animator weaponAnimator;
    [SerializeField] protected float attackCounterResetCooldown = 0.5f;

    protected Core core;
    protected PlayerAttackState state;
    [SerializeField] protected int currentAttackCounter;
    public int CurrentAttackCounter
    {
        get => currentAttackCounter;
        private set => currentAttackCounter = value >= weaponData.AmountOfAttacks ? 0 : value;
    }

    private Timer attackCounterResetTimer;
    protected virtual void Awake()
    {
        if (weaponData == null)
        {
            Debug.LogError("Wrong data for the Weapon");
        }
        
        // baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

        attackCounterResetTimer = new Timer(attackCounterResetCooldown);
        
        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        StartAttackWeapon();
    }

    public virtual void ExitWeapon()
    {
        // baseAnimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        CurrentAttackCounter++;
        
        attackCounterResetTimer.StartTimer();

        gameObject.SetActive(false);
    }

    private void StartAttackWeapon()
    {
        gameObject.SetActive(true);

        attackCounterResetTimer.Tick();
        
        // baseAnimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);
        
        // baseAnimator.SetInteger("attackCounter", attackCounter);
        weaponAnimator.SetInteger("attackCounter", currentAttackCounter);
    }
    private void ResetAttackCounter()
    {
        Debug.Log("Reset attack counter");
        CurrentAttackCounter = 0;
    }
    private void OnEnable()
    {
        attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
    }
    
    private void OnDisable()
    {
        attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
    }

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        // state.SetPlayerVelocity(weaponData.MovementSpeed[currentAttackCounter]);
    }
    
    public virtual void AnimationStopMovementTrigger()
    {
        // state.SetPlayerVelocity(0f);
    }

    public virtual void AnimationTurnOffFlipTrigger()
    {
        // state.SetFlipCheck(false);
    }
    
    public virtual void AnimationTurnOnFlipTrigger()
    {
        // state.SetFlipCheck(true);
    }

    public virtual void AnimationActionTrigger()
    {
        
    }

    public void InitializeWeapon(PlayerAttackState state, Core core)
    {
        this.state = state;
        this.core = core;
    }
}
