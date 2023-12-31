﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AggressiveWeapon : Weapon
{
        private List<IDamageable> detectedDamageables = new List<IDamageable>();
        private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();

        public override void AnimationActionTrigger()
        {
                base.AnimationActionTrigger();
                
                CheckMeleeAttack();
        }

        private void CheckMeleeAttack()
        {
                WeaponAttackDetails details = weaponData.AttackDetails[currentAttackCounter];

                foreach (IDamageable item in detectedDamageables.ToList())
                {
                        item.Damage(details.damageAmount);
                }
                
                foreach (IKnockbackable item in detectedKnockbackables.ToList())
                {
                        item.Knockback(details.knockbackAngle, details.knockbackStrength, core.Movement.FacingDirection);
                }
        }

        public void AddToDetected(Collider2D collision)
        {
                IDamageable damageable = collision.GetComponent<IDamageable>();

                if (damageable != null)
                {
                        detectedDamageables.Add(damageable);
                }
                
                IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();
                
                if (knockbackable != null)
                {
                        detectedKnockbackables.Add(knockbackable);
                }
        }
        
        public void RemoveFromDetected(Collider2D collision)
        {
                IDamageable damageable = collision.GetComponent<IDamageable>();

                if (damageable != null)
                {
                        detectedDamageables.Remove(damageable);
                }
                
                IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();
                
                if (knockbackable != null)
                {
                        detectedKnockbackables.Remove(knockbackable);
                }
        }
}