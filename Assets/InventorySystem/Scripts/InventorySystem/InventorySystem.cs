using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystem : MyMonoBehaviour, ISaveManager
{
    public static event Action<List<InventorySlot>> OnInventoryChange;
    
    public GameObject itemPrefab;
    public int size = 5;
    
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();

    public List<InventorySlot> itemList = new List<InventorySlot>();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadListInventorySlot();
        LoadItemPrefab();
    }

    private void Update()
    {
        GetItemBase();
    }

    private void LoadListInventorySlot()
    {
        if(inventorySlots.Count == size) return;
        
        if (inventorySlots.Count < size)
        {
            int newCount = size - inventorySlots.Count;
            inventorySlots.AddRange(new InventorySlot[newCount]);
            Debug.Log(transform.name + ": LoadListInventorySlotToAdd", gameObject);
        }
        else
        {
            int newCount = inventorySlots.Count - size;
            inventorySlots.RemoveRange(size, newCount);
            Debug.Log(transform.name + ": LoadListInventorySlotToRemove", gameObject);
        }
    }

    public bool IsFull()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.IsEmptySlot()) return false;
        }
        return true;
    }

    public InventorySlot FindSlot(ItemData itemData)
    {
        return inventorySlots.FirstOrDefault(slot => slot.ItemData == itemData && slot.CanAddAmountToStackSize());
    }
    
    public bool CanAddItem(ItemData itemData)
    {
        InventorySlot slotWithStackableItem = FindSlot(itemData);
        return !IsFull() || slotWithStackableItem != null;
    }

    public void AddItem(ItemData itemToAdd, int amountToAdd)
    {
        InventorySlot slotHasItem = FindSlot(itemToAdd);
        
        if (slotHasItem != null)
        {
            AddItemToSlot(slotHasItem, itemToAdd,amountToAdd);
        }
        else
        {
            AddItemToEmptySlot(itemToAdd, amountToAdd);
        }
        
        OnInventoryChange?.Invoke(inventorySlots);
    }

    public void AddItemToSlot(InventorySlot slot, ItemData itemToAdd, int amountToAdd)
    {
        int amountCanAdd = slot.ItemData.maxStackSize - slot.StackSize;
        if (amountToAdd <= amountCanAdd)
        {
            slot.AddToStack(amountToAdd);
        }
        else
        {
            slot.AddToStack(amountCanAdd);
            amountToAdd -= amountCanAdd;
            AddItem(itemToAdd, amountToAdd);
        }
    }
    public void AddItemToEmptySlot(ItemData itemToAdd, int amountToAdd)
    {
        for (int i = 0; i < size; i++)
        {
            if (inventorySlots[i].IsEmptySlot())
            {
                if (amountToAdd <= itemToAdd.maxStackSize)
                {
                    inventorySlots[i] = new InventorySlot(itemToAdd, amountToAdd);
                    amountToAdd = 0;
                }
                else
                {
                    inventorySlots[i] = new InventorySlot(itemToAdd, itemToAdd.maxStackSize);
                    amountToAdd -= itemToAdd.maxStackSize;
                }
            }

            if (amountToAdd <= 0)
            {
                break;
            }
        }
        if (amountToAdd > 0)
        {
            // Debug.Log("Can't add " + itemToAdd.itemName + ": amount: " + amountToAdd);
            
            Vector3 pos = PlayerInteract.Instance.transform.position + Vector3.left * 2;
            GameObject newItem = Instantiate(itemPrefab, pos, Quaternion.identity);
            newItem.TryGetComponent(out Item item);
            item.UpdateItem(itemToAdd, amountToAdd);
        }
    }
    // public void AddItem(ItemData itemToAdd, int amountToAdd)
    // {
    //     for (int i = 0; i < inventorySlots.Count; i++)
    //     {
    //         var inventorySlot = inventorySlots[i];
    //         
    //         if (inventorySlot.ItemData == itemToAdd)
    //         {
    //             if (inventorySlot.IsStackable)
    //             {
    //                 int amountCanAdd = inventorySlot.MaxStackSize - inventorySlot.StackSize;
    //                 if (amountToAdd <= amountCanAdd)
    //                 {
    //                     inventorySlot.AddToStack(amountToAdd);
    //                     amountToAdd = 0;
    //                 }
    //                 else
    //                 {
    //                     inventorySlot.AddToStack(amountCanAdd);
    //                     amountToAdd -= amountCanAdd;
    //                 }
    //             }
    //         }
    //         
    //         if (inventorySlot.IsEmptySlot())
    //         {
    //             int amountCanAdd = Mathf.Min(amountToAdd, itemToAdd.maxStackSize);
    //             inventorySlots[i] = new InventorySlot(itemToAdd, amountCanAdd);
    //             amountToAdd -= amountCanAdd;
    //         }
    //         
    //         if (amountToAdd <= 0)
    //         {
    //             break;
    //         }
    //     }
    //     if (amountToAdd > 0)
    //     {
    //         Debug.Log($"Inventory is full. itemToAdd: {itemToAdd}, amountToAdd: {amountToAdd}");
    //         //TODO: Create item with amount item remain in environment
    //     }
    //     OnInventoryChange?.Invoke(inventorySlots);
    // }

    public void AddItemToSpecifiedSlot(ItemData itemToAdd, int amountToAdd, int position)
    {
        if(amountToAdd <= 0) return;
        
        var inventorySlot = inventorySlots[position];
        
        if (inventorySlot.IsEmptySlot())
        {
            inventorySlots[position] = new InventorySlot(itemToAdd, amountToAdd);
        }
        else
        {
            if (inventorySlot.ItemData == itemToAdd)
            {
                if (inventorySlot.IsStackable)
                {
                    int amountCanAdd = inventorySlot.MaxStackSize - inventorySlot.StackSize;
                    if (amountToAdd <= amountCanAdd)
                    {
                        inventorySlot.AddToStack(amountToAdd);
                    }
                }
            }
        }
        OnInventoryChange?.Invoke(inventorySlots);
    } 
    
    public void RemoveItemFromSpecifiedSlot(InventorySlot inventorySlot, int amountToRemove)
    {
        if(amountToRemove <= 0) return;
        
        inventorySlot.RemoveFromStack(amountToRemove);
        inventorySlot.CheckStackSize();
        OnInventoryChange?.Invoke(inventorySlots);
    }

    public void RemoveItem(ItemData itemToRemove, int amountToRemove)
    {
        foreach (InventorySlot inventorySlot in inventorySlots)
        {
            if(inventorySlot.ItemData != itemToRemove) continue;
            
            int amountCanRemove = Mathf.Min(amountToRemove, inventorySlot.StackSize);
            inventorySlot.RemoveFromStack(amountCanRemove);
            amountToRemove -= amountCanRemove;
            
            if (inventorySlot.StackSize <= 0)
            {
                inventorySlot.ClearSlot();
            }
            
            if (amountToRemove <= 0)
            {
                break;
            }
        }
        if (amountToRemove > 0)
        {
            Debug.Log($"Inventory is not contains itemToRemove: {itemToRemove}, amountRemain: {amountToRemove}");
            //TODO: not enough item stackSize in inventory to remove
        }
        OnInventoryChange?.Invoke(inventorySlots);
    }

    public bool HasItem(ItemData itemData, int amount)
    {
        int count = 0;
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.HasItem() == itemData)
            {
                count += slot.StackSize;
            }
        }

        if (count >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveAllItem()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            slot.ClearSlot();
        }
        OnInventoryChange?.Invoke(inventorySlots);
    }

    private void LoadItemPrefab()
    {
        if(itemPrefab != null) return;
        itemPrefab = Resources.Load<GameObject>("Prefabs/ItemPrefab");
        Debug.LogWarning(transform.name + "LoadItemPrefab", gameObject);
    }

    public void LoadData(GameData data)
    {
        foreach (InventorySlot inventorySlot in data.inventory)
        {
            if (inventorySlot.ItemData == null)
            {
                itemList.Add(new InventorySlot());
            }
            else
            {
                itemList.Add(inventorySlot);
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        data.inventory.Clear();

        foreach (InventorySlot inventorySlot in inventorySlots)
        {
            data.inventory.Add(inventorySlot);
        }
    }

    private void GetItemBase()
    {
        if(itemList.Count == 0) return;

        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].IsEmptySlot())
            {
                continue;
            }

            AddItemToSpecifiedSlot(itemList[i].ItemData, itemList[i].StackSize, i);
        }
        
        itemList.Clear();
    }
}