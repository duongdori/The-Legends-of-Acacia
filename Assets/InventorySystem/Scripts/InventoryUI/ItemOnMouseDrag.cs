using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemOnMouseDrag : MyMonoBehaviour
{
    public GameObject itemPrefab;
    [SerializeField] private Image icon;
    public int slotBefore;
    public bool isDropped;
    
    public InventorySlot inventorySlot;


    protected override void Start()
    {
        base.Start();
        SetActiveSelf();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadIcon();
        LoadItemPrefab();
    }

    public void SetItemDrag(ItemData itemData, int amount, int slotOrderNumber)
    {
        icon.enabled = true;
        icon.sprite = itemData.itemIcon;
        inventorySlot = new InventorySlot(itemData, amount);
        slotBefore = slotOrderNumber;
    }
    public void DropItemOnGround()
    {
        Vector3 test = new Vector3(PlayerCtrl.Instance.Player.FacingDirection, 0f, 0f);
        Vector3 pos = PlayerInteract.Instance.transform.position + test * 2;
        GameObject newItem = Instantiate(itemPrefab, pos, Quaternion.identity);
        newItem.TryGetComponent(out Item item);
        item.UpdateItem(inventorySlot.ItemData, inventorySlot.StackSize);
        ClearItemOnMouseDrag();
    }
    public void ClearItemOnMouseDrag()
    {
        inventorySlot.ClearSlot();
        icon.sprite = null;
        icon.enabled = false;
        slotBefore = -1;
        SetActiveSelf();
    }

    public void SetActiveSelf()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    public void ItemOnMousePos(Vector3 mousePos)
    {
        transform.position = mousePos;
    }
    private void LoadIcon()
    {
        if(icon != null) return;
        icon = GetComponentInChildren<Image>();
        icon.enabled = false;
        Debug.LogWarning(transform.name + ": LoadIcon", gameObject);
    }
    
    private void LoadItemPrefab()
    {
        if(itemPrefab != null) return;
        itemPrefab = Resources.Load<GameObject>("Prefabs/ItemPrefab");
        Debug.LogWarning(transform.name + "LoadItemPrefab", gameObject);
    }
}
