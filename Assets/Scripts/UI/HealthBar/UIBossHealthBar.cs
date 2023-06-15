using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBossHealthBar : UIHealthBar
{
    protected override void LoadStats()
    {
        base.LoadStats();
        if(stats != null) return;
        stats = FindObjectOfType<BossStats>().GetComponent<BossStats>();
        Debug.LogWarning(transform.name + " LoadStats", gameObject);
    }
}
