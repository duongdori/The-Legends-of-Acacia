using UnityEngine;
using UnityEngine.EventSystems;

public class DroppableItem : MyMonoBehaviour, IDropHandler
{
    public ItemOnMouseDrag itemOnMouseDrag;
    public SlotUI slotUI;
    public InventoryUI inventoryUI;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left &&
            eventData.button != PointerEventData.InputButton.Right) return;
        
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        if(draggableItem == null) return;
        
        DropItemToSlot();
    }

    private void DropItemToSlot()
    {
        if (slotUI.InventorySlot.IsEmptySlot())
        {
            DropItemToEmptySlot();
            return;
        }
        DropToSlotHasItem();
    }
    private void DropItemToEmptySlot()
    {
        slotUI.AddItemToSlot(itemOnMouseDrag.inventorySlot);
        itemOnMouseDrag.ClearItemOnMouseDrag();
        itemOnMouseDrag.isDropped = true;
        Debug.Log("Dropped");
    }

    private void DropToSlotHasItem()
    {
        if (itemOnMouseDrag.inventorySlot.ItemData == slotUI.InventorySlot.ItemData && slotUI.InventorySlot.CanAddAmountToStackSize())
        {
            int amountCanAdd = slotUI.InventorySlot.MaxStackSize - slotUI.InventorySlot.StackSize;
            if (itemOnMouseDrag.inventorySlot.StackSize <= amountCanAdd)
            {
                slotUI.AddItemToSlot(itemOnMouseDrag.inventorySlot);
                itemOnMouseDrag.ClearItemOnMouseDrag();
                itemOnMouseDrag.isDropped = true;
                return;
            }
            int amountRemain = itemOnMouseDrag.inventorySlot.StackSize - amountCanAdd;
            slotUI.AddItemToSlot(itemOnMouseDrag.inventorySlot, amountCanAdd);
            inventoryUI.SlotUIList[itemOnMouseDrag.slotBefore].AddItemToSlot(itemOnMouseDrag.inventorySlot, amountRemain);
            itemOnMouseDrag.ClearItemOnMouseDrag();
            itemOnMouseDrag.isDropped = true;
            return;
        }
        SwapItemSlot();
    }
    private void SwapItemSlot()
    {
        if (inventoryUI.SlotUIList[itemOnMouseDrag.slotBefore].InventorySlot.IsEmptySlot())
        {
            InventorySlot tempSlot = new InventorySlot(slotUI.InventorySlot.ItemData, slotUI.InventorySlot.StackSize);
            slotUI.ClearSlotUI();
            slotUI.AddItemToSlot(itemOnMouseDrag.inventorySlot);
            inventoryUI.SlotUIList[itemOnMouseDrag.slotBefore].AddItemToSlot(tempSlot);
            itemOnMouseDrag.ClearItemOnMouseDrag();
            itemOnMouseDrag.isDropped = true;
        }
        else
        {
            inventoryUI.SlotUIList[itemOnMouseDrag.slotBefore].AddItemToSlot(itemOnMouseDrag.inventorySlot);
            itemOnMouseDrag.ClearItemOnMouseDrag();
            itemOnMouseDrag.isDropped = true;
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent();
    }
    
    public void LoadComponent()
    {
        LoadItemOnMouseDrag();
        LoadSlotUI();
        LoadInventoryUI();
    }
    private void LoadItemOnMouseDrag()
    {
        if(itemOnMouseDrag != null) return;
        itemOnMouseDrag = FindObjectOfType<ItemOnMouseDrag>().GetComponent<ItemOnMouseDrag>();
        Debug.LogWarning(transform.name + ": LoadItemOnMouseDrag", gameObject);
    }
    private void LoadSlotUI()
    {
        if(slotUI != null) return;
        slotUI = GetComponent<SlotUI>();
        Debug.LogWarning(transform.name + ": LoadSlotUI", gameObject);
    }
    private void LoadInventoryUI()
    {
        if(inventoryUI != null) return;
        inventoryUI = GetComponentInParent<InventoryUI>();
        Debug.LogWarning(transform.name + ": LoadInventoryUI", gameObject);
    }
}
