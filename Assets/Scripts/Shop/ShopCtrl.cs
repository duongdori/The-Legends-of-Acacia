using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCtrl : MyMonoBehaviour
{
    public GameObject buttonE;
    public UI_UpgradeSystem upgradeSystemUI;

    private bool isActive;

    private void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                upgradeSystemUI.upgradeUI.SetActive(!upgradeSystemUI.upgradeUI.activeSelf);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            buttonE.SetActive(true);
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            buttonE.SetActive(false);
            isActive = false;
            upgradeSystemUI.upgradeUI.SetActive(false);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadButtonE();
        LoadUpgradeSystemUI();
        buttonE.SetActive(false);
    }

    private void LoadButtonE()
    {
        if(buttonE != null) return;
        buttonE = transform.Find("ButtonE").gameObject;
        Debug.LogWarning(transform.name + " LoadButtonE", gameObject);
    }
    
    private void LoadUpgradeSystemUI()
    {
        if(upgradeSystemUI != null) return;
        upgradeSystemUI = FindObjectOfType<UI_UpgradeSystem>().GetComponent<UI_UpgradeSystem>();
        Debug.LogWarning(transform.name + " LoadUpgradeSystemUI", gameObject);
    }
}
