using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
   public float currentHealth;

   public int sceneIndex;

   public Vector3 playerPos;

   public List<InventorySlot> inventory;
   public List<int> listUpgradeCurrentLevel;

   public List<float> healthModifier;
   public List<float> damageModifier;
   public List<float> moveSpeedModifier;
   public GameData()
   {
      inventory = new List<InventorySlot>();
      listUpgradeCurrentLevel = new List<int>();
      healthModifier = new List<float>();
      damageModifier = new List<float>();
      moveSpeedModifier = new List<float>();
   }
}
