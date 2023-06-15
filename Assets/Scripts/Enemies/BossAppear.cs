using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear : MyMonoBehaviour
{
    public Boss_Shaman boss;
    public GameObject healthBarUI;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoss();
        LoadHealthBar();
    }
    protected override void Start()
    {
        base.Start();
        boss.gameObject.SetActive(false);
        healthBarUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            boss.gameObject.SetActive(true);
            healthBarUI.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void LoadBoss()
    {
        if (boss != null) return;
        boss = FindObjectOfType<Boss_Shaman>().GetComponent<Boss_Shaman>();
        Debug.LogWarning(transform.name + " LoadBoss", gameObject);
    }

    private void LoadHealthBar()
    {
        if (healthBarUI != null) return;
        healthBarUI = GameObject.Find("BossHealthBar");
        Debug.LogWarning(transform.name + " LoadHealthBar", gameObject);
    }
}
