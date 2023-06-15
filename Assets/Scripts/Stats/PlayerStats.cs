using UnityEngine;

public class PlayerStats : CharacterStats, ISaveManager
{
    [SerializeField] private Player player;
    protected override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        player.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();
        player.Die();
    }

    public void SetCurrentHealth(float amount)
    {
        float amountCanAdd = maxHealth.GetValue() - currentHealth;

        if (amount >= amountCanAdd)
        {
            currentHealth = maxHealth.GetValue();
        }
        else
        {
            currentHealth += amount;
        }
    }
    public void LoadData(GameData data)
    {
        LoadHealthModifier(data);
        LoadDamageModifier(data);
        LoadMoveSpeedModifier(data);
        
        if (data.currentHealth <= 0f)
        {
            this.currentHealth = maxHealth.GetValue();
        }
        else
        {
            this.currentHealth = data.currentHealth;
        }
        
    }

    public void SaveData(ref GameData data)
    {
        data.currentHealth = this.currentHealth;
        SaveHealthModifier(data);
        SaveDamageModifier(data);
        SaveMoveSpeedModifier(data);
    }

    private void SaveHealthModifier(GameData data)
    {
        data.healthModifier.Clear();
        if(maxHealth.modifiers.Count == 0) return;

        foreach (float value in maxHealth.modifiers)
        {
            data.healthModifier.Add(value);
        }
    }
    
    private void SaveDamageModifier(GameData data)
    {
        data.damageModifier.Clear();
        if(damage.modifiers.Count == 0) return;

        foreach (float value in damage.modifiers)
        {
            data.damageModifier.Add(value);
        }
    }
    
    private void SaveMoveSpeedModifier(GameData data)
    {
        data.moveSpeedModifier.Clear();
        if(moveSpeed.modifiers.Count == 0) return;

        foreach (float value in moveSpeed.modifiers)
        {
            data.moveSpeedModifier.Add(value);
        }
    }

    private void LoadHealthModifier(GameData data)
    {
        if(data.healthModifier.Count == 0) return;

        foreach (float value in data.healthModifier)
        {
            maxHealth.AddModifier(value);
        }
        
    }
    
    private void LoadDamageModifier(GameData data)
    {
        if(data.damageModifier.Count == 0) return;

        foreach (float value in data.damageModifier)
        {
            damage.AddModifier(value);
        }
        
    }
    
    private void LoadMoveSpeedModifier(GameData data)
    {
        if(data.moveSpeedModifier.Count == 0) return;

        foreach (float value in data.moveSpeedModifier)
        {
            moveSpeed.AddModifier(value);
        }
        
    }
}