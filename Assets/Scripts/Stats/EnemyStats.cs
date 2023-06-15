using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private Enemy enemy;
    protected override void Start()
    {
        base.Start();
        currentHealth = maxHealth.GetValue();
        enemy = GetComponent<Enemy>();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        enemy.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();
        enemy.Die();
    }
}