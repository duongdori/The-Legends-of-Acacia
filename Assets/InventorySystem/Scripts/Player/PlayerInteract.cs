using System;
using UnityEngine;

public class PlayerInteract : MyMonoBehaviour
{
    private static PlayerInteract instance;
    public static PlayerInteract Instance => instance;

    public InventorySystem inventorySystem;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Debug.LogError("There is more than one PlayerInteract instance");
        }
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInventorySystem();
    }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     Item item = col.GetComponent<Item>();
    //     if(item == null) return;
    //     if(!inventorySystem.CanAddItem(item.itemData)) return;
    //     item.PickUpItem(inventorySystem);
    // }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Item item = other.gameObject.GetComponent<Item>();
        if(item == null) return;
        if(!inventorySystem.CanAddItem(item.itemData)) return;
        item.PickUpItem(inventorySystem);
    }

    private void LoadInventorySystem()
    {
        if(inventorySystem != null) return;
        inventorySystem = FindObjectOfType<InventorySystem>().GetComponent<InventorySystem>();
        Debug.LogWarning(transform.name + "LoadInventorySystem", gameObject);
    }
}
