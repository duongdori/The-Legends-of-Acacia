using UnityEngine;

public class UIEnemyHealthBar : UIHealthBar
{
    protected override void LoadBaseEntity()
    {
        base.LoadBaseEntity();
        if(entity != null) return;
        entity = GetComponentInParent<Entity>();
        Debug.LogWarning(transform.name + " LoadBaseEntity", gameObject);
    }

    protected override void LoadStats()
    {
        base.LoadStats();
        if(stats != null) return;
        stats = GetComponentInParent<CharacterStats>();
        Debug.LogWarning(transform.name + " LoadStats", gameObject);
    }
}