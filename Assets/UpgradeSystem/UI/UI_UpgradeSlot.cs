using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_UpgradeSlot : MyMonoBehaviour
{
    public UpgradeStatsData data;
    public int level;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI levelText;
    public Button upgradeButton;


    private void Update()
    {
        levelText.text = "Lvl: " + level;
    }

    public void UpdateCostText(int cost)
    {
        costText.text = cost.ToString();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCostText();
        LoadLevelText();
        LoadUpgradeButton();
    }

    private void LoadCostText()
    {
        if(costText != null) return;
        costText = transform.Find("Resource").GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " LoadCostText", gameObject);
    }
    
    private void LoadLevelText()
    {
        if(levelText != null) return;
        levelText = transform.Find("Level").GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " LoadLevelText", gameObject);
    }
    
    private void LoadUpgradeButton()
    {
        if(upgradeButton != null) return;
        upgradeButton = GetComponentInChildren<Button>();
        Debug.LogWarning(transform.name + " LoadUpgradeButton", gameObject);
    }
}
