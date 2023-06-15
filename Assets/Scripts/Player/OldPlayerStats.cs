using UnityEngine;

public class OldPlayerStats : Stats
{
    public PlayerData playerData;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerData();
        SetMaxHealth(playerData.healthLevels[0]);
        SetCurrentHealth();
        
        SetMoveSpeed(playerData.moveSpeedLevels[0]);
    }
    
    private void Update()
    {
        CheckIsAttack();
    }

    private void CheckIsAttack()
    {
        if (attackCooldownTime < attackSpeed)
        {
            attackCooldownTime += Time.deltaTime;
            isAttack = false;
            return;
        }

        isAttack = true;
    }

    public override void SetIsAttack(bool value)
    {
        base.SetIsAttack(value);
        isAttack = value;
        attackCooldownTime = 0;
    }

    private void LoadPlayerData()
    {
        if(playerData != null) return;
        playerData = Resources.Load<PlayerData>("SO/PlayerData");
        Debug.LogWarning(transform.name + " LoadPlayerData", gameObject);
    }
}