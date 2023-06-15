using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Stats : CoreComponent
{
    #region Health Stats

    [Header("Health Stats")]
    [SerializeField] protected float currentHealth;
    public float CurrentHealth => currentHealth;
    
    [SerializeField] protected float maxHealth;
    public float MaxHealth => maxHealth;

    #endregion

    #region Move Stats

    [Header("Move Stats")]
    [SerializeField] private float moveSpeed;
    public float MoveSpeed => moveSpeed;
    
    #endregion

    #region Attack Stats

    [Header("Attack Stats")]
    [SerializeField] protected float attackSpeed;
    public float AttackSpeed => attackSpeed;
    public float attackCooldownTime;
    public bool isAttack;

    #endregion


    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
    }

    public void SetCurrentHealth()
    {
        currentHealth = maxHealth;
    }

    public void SetMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }
    
    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }

    public virtual void SetIsAttack(bool value)
    {
        
    }
}