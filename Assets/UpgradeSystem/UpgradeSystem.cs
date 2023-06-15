using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MyMonoBehaviour, ISaveManager
{
    public InventorySystem inventory;
    public PlayerStats playerStats;

    public List<UpgradeStats> upgradeStatsList;

    public List<int> listLevelBase;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInventory();
        LoadPlayerStats();
        LoadUpgradeData();
    }

    private void Update()
    {
        GetCurrentLevelBase();
    }

    public void UpgradeHP()
    {
        if(upgradeStatsList[0].currentLevel >= upgradeStatsList[0].statsData.maxLevel) return;
        
        ItemData resource = upgradeStatsList[0].statsData.resourceNeeded;
        int amount = upgradeStatsList[0].statsData.costs[upgradeStatsList[0].currentLevel];

        if (inventory.HasItem(resource, amount))
        {
            inventory.RemoveItem(resource, amount);
            upgradeStatsList[0].Upgrade();
            playerStats.maxHealth.AddModifier(10f);
        }
    }
    
    public void UpgradeDamage()
    {
        if(upgradeStatsList[1].currentLevel >= upgradeStatsList[1].statsData.maxLevel) return;
        
        ItemData resource = upgradeStatsList[1].statsData.resourceNeeded;
        int amount = upgradeStatsList[1].statsData.costs[upgradeStatsList[1].currentLevel];

        if (inventory.HasItem(resource, amount))
        {
            inventory.RemoveItem(resource, amount);
            upgradeStatsList[1].Upgrade();
            playerStats.damage.AddModifier(2f);
        }
    }
    
    public void UpgradeMoveSpeed()
    {
        if(upgradeStatsList[2].currentLevel >= upgradeStatsList[2].statsData.maxLevel) return;

        ItemData resource = upgradeStatsList[2].statsData.resourceNeeded;
        int amount = upgradeStatsList[2].statsData.costs[upgradeStatsList[2].currentLevel];

        if (inventory.HasItem(resource, amount))
        {
            inventory.RemoveItem(resource, amount);
            upgradeStatsList[2].Upgrade();
            playerStats.moveSpeed.AddModifier(1f);
        }
    }
    

    private void LoadInventory()
    {
        if(inventory != null) return;
        inventory = FindObjectOfType<InventorySystem>().GetComponent<InventorySystem>();
        Debug.LogWarning(transform.name + "LoadInventory", gameObject);
    }
    
    private void LoadPlayerStats()
    {
        if(playerStats != null) return;
        playerStats = FindObjectOfType<PlayerStats>().GetComponent<PlayerStats>();
        Debug.LogWarning(transform.name + "LoadPlayerStats", gameObject);
    }

    private void LoadUpgradeData()
    {
        upgradeStatsList = new List<UpgradeStats>();
        for (int i = 0; i < 3; i++)
        {
            upgradeStatsList.Add(new UpgradeStats());
        }

        upgradeStatsList[0].statsData = Resources.Load<UpgradeStatsData>("UpgradeData/HP");
        upgradeStatsList[1].statsData = Resources.Load<UpgradeStatsData>("UpgradeData/Damage");
        upgradeStatsList[2].statsData = Resources.Load<UpgradeStatsData>("UpgradeData/MoveSpeed");
    }

    public void LoadData(GameData data)
    {
        foreach (int currentLevel in data.listUpgradeCurrentLevel)
        {
            listLevelBase.Add(currentLevel);
        }
    }

    public void SaveData(ref GameData data)
    {
        data.listUpgradeCurrentLevel.Clear();
        
        foreach (UpgradeStats stats in upgradeStatsList)
        {
            data.listUpgradeCurrentLevel.Add(stats.currentLevel);
        }
    }
    
    private void GetCurrentLevelBase()
    {
        if(listLevelBase.Count == 0) return;

        for (int i = 0; i < listLevelBase.Count; i++)
        {
            upgradeStatsList[i].currentLevel = listLevelBase[i];
        }

        listLevelBase.Clear();
    }
}
