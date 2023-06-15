using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MyMonoBehaviour
{
    [SerializeField] private Movement movement;
    public Movement Movement => movement;
    
    [SerializeField] private CollisionSenses collisionSenses;
    public CollisionSenses CollisionSenses => collisionSenses;
    
    [SerializeField] private Combat combat;
    public Combat Combat => combat;
    
    [SerializeField] private Stats stats;
    public Stats Stats => stats;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCoreMovement();
        LoadCoreCollisionSenses();
        LoadCoreCombat();
        LoadCoreStats();
        
        if (!movement || !collisionSenses || !combat || !stats)
        {
            Debug.LogError("Missing Core Component");
        }
    }

    public void LogicUpdate()
    {
        movement.LogicUpdate();
    }

    private void LoadCoreMovement()
    {
        if(movement != null) return;
        movement = GetComponentInChildren<Movement>();
        Debug.LogWarning(transform.name + " LoadCoreMovement", gameObject);
    }
    
    private void LoadCoreCollisionSenses()
    {
        if(collisionSenses != null) return;
        collisionSenses = GetComponentInChildren<CollisionSenses>();
        Debug.LogWarning(transform.name + " LoadCoreCollisionSenses", gameObject);
    }
    
    private void LoadCoreCombat()
    {
        if(combat != null) return;
        combat = GetComponentInChildren<Combat>();
        Debug.LogWarning(transform.name + " LoadCoreCombat", gameObject);
    }
    
    private void LoadCoreStats()
    {
        if(stats != null) return;
        stats = GetComponentInChildren<Stats>();
        Debug.LogWarning(transform.name + " LoadCoreStats", gameObject);
    }
}
