using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
    public bool isHurt;
    public bool isdead;
    public void Damage(float amount)
    {
        core.Stats.DecreaseHealth(amount);
        isHurt = true;
        // Debug.Log(core.transform.parent.name + "Damaged! " + amount);

        if (core.Stats.CurrentHealth <= 0)
        {
            isdead = true;
        }
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);
    }
}
