using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Upgrade Data")]
public class UpgradeStatsData : ScriptableObject
{
    public ItemData resourceNeeded;
    public int maxLevel = 5;
    public List<int> costs;
}