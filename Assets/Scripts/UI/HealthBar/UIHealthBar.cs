using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIHealthBar : MyMonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] protected Entity entity;
    [SerializeField] protected CharacterStats stats;

    protected virtual void FixedUpdate()
    {
        UpdateHealthBar(stats.CurrentHealth, stats.maxHealth.GetValue());
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth / maxHealth;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSlider();
        LoadBaseEntity();
        LoadStats();
    }

    private void LoadSlider()
    {
        if(slider != null) return;
        slider = GetComponent<Slider>();
        Debug.LogWarning(transform.name + " LoadSlider", gameObject);
    }
    
    protected virtual void LoadStats()
    {
        
    }
    
    protected virtual void LoadBaseEntity()
    {
        
    }
}
