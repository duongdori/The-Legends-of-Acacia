using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public EnemyAttackState state;
    public float damageAmount;
    public Animator weaponAnimator;

    public IDamageable target;
    private void Awake()
    {
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
        
        gameObject.SetActive(false);
    }
    
    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        
        weaponAnimator.SetBool("attack", true);
        
    }
    
    public virtual void ExitWeapon()
    {
        weaponAnimator.SetBool("attack", false);
        
        gameObject.SetActive(false);
    }
    
    public void InitializeWeapon(EnemyAttackState state)
    {
        this.state = state;
    }

    public void AttackDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            target = damageable;
        }
    }
    
    public void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            target = null;
        }
    }

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }
    
    public virtual void AnimationActionTrigger()
    {
        if(target == null) return;
        
        target.Damage(damageAmount);
    }
}
