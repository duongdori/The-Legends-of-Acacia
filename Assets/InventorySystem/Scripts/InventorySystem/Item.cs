using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Item : MyMonoBehaviour
{
    public ItemData itemData;
    public int quantity = 0;
    public SpriteRenderer spriteRenderer;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpriteRenderer();
    }

    public void PickUpItem(InventorySystem inventorySystem)
    {
        inventorySystem.AddItem(itemData, quantity);
        Debug.Log(itemData.name);
        DestroyItem();
    }

    public void UpdateItem(ItemData item, int amount)
    {
        itemData = item;
        quantity = amount;
        LoadItemData();
    }
    private void OnValidate()
    {
        LoadItemData();
    }

    private void LoadItemData()
    {
        if(itemData == null)
        {
            transform.name = "ItemPrefab";
            spriteRenderer.sprite = null;
        }
        else
        {
            transform.name = itemData.itemName;
            spriteRenderer.sprite = itemData.itemIcon;
        }
    }
    private void DestroyItem()
    {
        Destroy(gameObject);
    }

    private void LoadSpriteRenderer()
    {
        if(spriteRenderer != null) return;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": LoadSpriteRenderer", gameObject);
    }
}
