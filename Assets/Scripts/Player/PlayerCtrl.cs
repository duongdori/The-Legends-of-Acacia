using System;
using UnityEngine;

public class PlayerCtrl : MyMonoBehaviour
{
    #region Singleton Variables
    
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;
    
    #endregion
    
    [SerializeField] private Player player;
    
    [SerializeField] private PlayerStats playerStats;
    public Player Player => player;
    public PlayerStats PlayerStats => playerStats;

    protected override void Awake()
    {
        base.Awake();
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void Set(bool value)
    {
        player.isInteract = value;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
        LoadPlayerStats();
    }
    
    private void LoadPlayer()
    {
        if(player != null) return;
        player = transform.GetComponent<Player>();
        Debug.LogWarning(transform.name + " LoadPlayer", gameObject);
    }
    
    private void LoadPlayerStats()
    {
        if(playerStats != null) return;
        playerStats = transform.GetComponent<PlayerStats>();
        Debug.LogWarning(transform.name + " LoadPlayerStats", gameObject);
    }
}