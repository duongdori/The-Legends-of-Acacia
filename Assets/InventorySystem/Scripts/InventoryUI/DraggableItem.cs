using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MyMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public SlotUI slotUI;
    public ItemOnMouseDrag itemOnMouseDrag;
    
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GetItemFromSlotToDrag(slotUI.InventorySlot.ItemData, slotUI.InventorySlot.StackSize, slotUI.OrderNumber);
            Debug.Log("Begin Drag");
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (slotUI.InventorySlot.StackSize > 1)
            {
                itemOnMouseDrag.SetActiveSelf();
                itemOnMouseDrag.SetItemDrag(slotUI.InventorySlot.ItemData, slotUI.InventorySlot.SplitFromStack(), slotUI.OrderNumber);
                slotUI.UpdateSlotUI(slotUI.InventorySlot);
                itemOnMouseDrag.isDropped = false;
                Debug.Log("Begin SplitItem Drag");
                return;
            }
            
            GetItemFromSlotToDrag(slotUI.InventorySlot.ItemData, slotUI.InventorySlot.StackSize, slotUI.OrderNumber);
            Debug.Log("Begin SplitItem Drag");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(Camera.main == null) return;
        
        Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        
        if (eventData.button != PointerEventData.InputButton.Left &&
            eventData.button != PointerEventData.InputButton.Right) return;
        
        itemOnMouseDrag.ItemOnMousePos(mousePos);
        Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left &&
            eventData.button != PointerEventData.InputButton.Right) return;
        
        if(itemOnMouseDrag.isDropped) return;
        itemOnMouseDrag.DropItemOnGround();
        // slotUI.AddItemToSlot(itemOnMouseDrag.inventorySlot);
        // itemOnMouseDrag.ClearItemOnMouseDrag();
        Debug.Log("End Drag");
    }
    
    private void GetItemFromSlotToDrag(ItemData itemData, int amount, int orderNumber)
    {
        itemOnMouseDrag.SetActiveSelf();
        itemOnMouseDrag.SetItemDrag(itemData, amount, orderNumber);
        slotUI.ClearSlotUI();
        itemOnMouseDrag.isDropped = false;
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
        slotUI = GetComponentInParent<SlotUI>();
        Debug.LogWarning(transform.name + ": LoadSlotUI", gameObject);
    }
    
}
