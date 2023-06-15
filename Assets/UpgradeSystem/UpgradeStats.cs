using UnityEngine;
using System;

[Serializable]
public class UpgradeStats
{
    public UpgradeStatsData statsData;
    public int currentLevel;

    public UpgradeStats()
    {
    }

    public void Upgrade()
    {
        currentLevel++;
    }
}