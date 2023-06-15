using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class InventorySlot
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int stackSize;
    
    public ItemData ItemData => itemData;
    public int StackSize => stackSize;
    
    public int MaxStackSize => itemData.maxStackSize;
    public bool IsStackable => itemData.isStackable;
    public InventorySlot(ItemData item, int amount)
    {
        itemData = item;
        stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }
    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }
    
    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }

    public void CheckStackSize()
    {
        if (stackSize <= 0)
        {
            ClearSlot();
        }
    }
    public int SplitFromStack()
    {
        int amountRemain = stackSize / 2;
        RemoveFromStack(amountRemain);
        return amountRemain;
    }
    public bool CanAddAmountToStackSize()
    {
        return stackSize < itemData.maxStackSize;
    }
    public bool IsEmptySlot()
    {
        return itemData == null;
    }

    public ItemData HasItem()
    {
        if (itemData != null)
        {
            return itemData;
        }

        return null;
    }
}
