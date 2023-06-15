using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
    [SerializeField] private float baseValue;

    public List<float> modifiers = new List<float>();

    public float GetValue()
    {
        float finalValue = baseValue;

        foreach (float modifier in modifiers)
        {
            finalValue += modifier;
        }
        return finalValue;
    }

    public void AddModifier(float modifier)
    {
        modifiers.Add(modifier);
    }
    
    public void RemoveModifier(float modifier)
    {
        modifiers.Remove(modifier);
    }
}
