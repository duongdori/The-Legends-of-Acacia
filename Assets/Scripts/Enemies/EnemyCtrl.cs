using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyCtrl : MyMonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public Enemy Enemy => enemy;
    
    [FormerlySerializedAs("enemyAnimationTrigger")] [FormerlySerializedAs("enemyModel")] [SerializeField] private Enemy_GoblinAnimationTrigger enemyGoblinAnimationTrigger;
    public Enemy_GoblinAnimationTrigger EnemyGoblinAnimationTrigger => enemyGoblinAnimationTrigger;
    
    [SerializeField] private Core core;
    public Core Core => core;

    [SerializeField] private UIHealthBar uIHealthBar;
    public UIHealthBar UIHealthBar => uIHealthBar;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemy();
        LoadEnemyModel();
        LoadEnemyCore();
        LoadUIHealthBar();
    }

    private void LoadEnemy()
    {
        if(enemy != null) return;
        enemy = transform.GetComponent<Enemy>();
        Debug.LogWarning(transform.name + " LoadEnemy", gameObject);
    }
    
    private void LoadEnemyModel()
    {
        if(enemyGoblinAnimationTrigger != null) return;
        enemyGoblinAnimationTrigger = transform.GetComponentInChildren<Enemy_GoblinAnimationTrigger>();
        Debug.LogWarning(transform.name + " LoadEnemyModel", gameObject);
    }
    
    private void LoadEnemyCore()
    {
        if(core != null) return;
        // core = enemy.Core;
        Debug.LogWarning(transform.name + " LoadEnemyCore", gameObject);
    }
    
    private void LoadUIHealthBar()
    {
        if(uIHealthBar != null) return;
        uIHealthBar = GetComponentInChildren<UIHealthBar>();
        Debug.LogWarning(transform.name + " LoadUIHealthBar", gameObject);
    }
}
