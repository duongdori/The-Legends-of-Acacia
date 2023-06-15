using UnityEngine;

public class OldEnemyStats : Stats
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        SetMaxHealth(100f);
        SetCurrentHealth();
    }
}