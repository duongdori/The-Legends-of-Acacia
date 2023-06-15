using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "SO/WeaponData")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private WeaponAttackDetails[] attackDetails;
    public WeaponAttackDetails[] AttackDetails => attackDetails;
    
    [SerializeField] private int amountOfAttacks;
    public int AmountOfAttacks => amountOfAttacks;
    
    private float[] movementSpeed;
    public float[] MovementSpeed => movementSpeed;
    
    private void OnEnable()
    {
        amountOfAttacks = attackDetails.Length;

        movementSpeed = new float[amountOfAttacks];

        for (int i = 0; i < amountOfAttacks; i++)
        {
            movementSpeed[i] = attackDetails[i].movementSpeed;
        }
    }
}
