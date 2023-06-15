using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UpgradeSystem : MyMonoBehaviour
{
   public GameObject upgradeUI;
   public UpgradeSystem upgradeSystem;
   public List<UI_UpgradeSlot> listUpgradeSlots;

   protected override void LoadComponents()
   {
      base.LoadComponents();
      LoadUpgradeUI();
      LoadUpgradeSystem();
      LoadUpgradeSlots();
      UpdateUI();
      upgradeUI.SetActive(false);
   }

   private void Update()
   {
      UpdateUI();
   }

   public void CheckResource()
   {
      for (int i = 0; i < listUpgradeSlots.Count; i++)
      {
         ItemData resource = upgradeSystem.upgradeStatsList[i].statsData.resourceNeeded;
         int amount = upgradeSystem.upgradeStatsList[i].statsData.costs[upgradeSystem.upgradeStatsList[i].currentLevel];
         if (upgradeSystem.inventory.HasItem(resource, amount))
         {
            listUpgradeSlots[i].upgradeButton.interactable = true;
         }
         else
         {
            listUpgradeSlots[i].upgradeButton.interactable = false;
         }
      }

   }

   public void UpgradeHP()
   {
      upgradeSystem.UpgradeHP();
      UpdateUI();
   }
   
   public void UpgradeDamage()
   {
      upgradeSystem.UpgradeDamage();
      UpdateUI();
   }
   
   public void UpgradeMoveSpeed()
   {
      upgradeSystem.UpgradeMoveSpeed();
      UpdateUI();
   }
   private void UpdateUI()
   {
      for (int i = 0; i < listUpgradeSlots.Count ; i++)
      {
         int level = upgradeSystem.upgradeStatsList[i].currentLevel;
         listUpgradeSlots[i].UpdateCostText(upgradeSystem.upgradeStatsList[i].statsData.costs[level]);

         listUpgradeSlots[i].data = upgradeSystem.upgradeStatsList[i].statsData;
         listUpgradeSlots[i].level = upgradeSystem.upgradeStatsList[i].currentLevel;
      }
   }

   private void LoadUpgradeUI()
   {
      if(upgradeUI != null) return;
      upgradeUI = transform.GetChild(0).gameObject;
      Debug.LogWarning(transform.name + "LoadUpgradeUI", gameObject);
   }
   
   private void LoadUpgradeSystem()
   {
      if(upgradeSystem != null) return;
      upgradeSystem = FindObjectOfType<UpgradeSystem>().GetComponent<UpgradeSystem>();
      Debug.LogWarning(transform.name + "LoadUpgradeSystem", gameObject);
   }

   private void LoadUpgradeSlots()
   {
      if(listUpgradeSlots.Count > 0) return;
      UI_UpgradeSlot[] upgradeSlots = GetComponentsInChildren<UI_UpgradeSlot>();

      for (int i = 0; i < upgradeSlots.Length; i++)
      {
         listUpgradeSlots.Add(upgradeSlots[i]);
      }
      
      Debug.LogWarning(transform.name + "LoadUpgradeSlots", gameObject);
   }
}
