using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected float currentHealth;
    public float CurrentHealth => currentHealth;
    
    public Stat maxHealth;
    public Stat damage;
    public Stat strength;
    public Stat moveSpeed;

    protected virtual void Start()
    {
        //currentHealth = maxHealth.GetValue();
    }

    public virtual void DoDamage(CharacterStats targetStats)
    {

        float totalDamage = damage.GetValue() + strength.GetValue();
        targetStats.TakeDamage(totalDamage);
    }
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        
    }
}
