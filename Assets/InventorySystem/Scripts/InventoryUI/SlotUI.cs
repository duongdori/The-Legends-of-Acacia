using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotUI : MyMonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private DraggableItem draggableItem;
    [SerializeField] private DroppableItem droppableItem;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI stackSizeText;
    [SerializeField] private int orderNumber;
    public int OrderNumber => orderNumber;
    public InventorySystem InventorySystem => inventoryUI.InventorySystem;
    public InventorySlot InventorySlot => InventorySystem.inventorySlots[orderNumber];


    public void ClearSlotUI()
    {
        InventorySlot.ClearSlot();
        icon.enabled = false;
        stackSizeText.enabled = false;
    }
    public void UpdateSlotUI(InventorySlot inventorySlot)
    {
        if (inventorySlot.IsEmptySlot())
        {
            ClearSlotUI();
            return;
        }
        
        icon.enabled = true;
        stackSizeText.enabled = true;

        icon.sprite = inventorySlot.ItemData.itemIcon;
        stackSizeText.text = inventorySlot.StackSize.ToString();
        
        if(InventorySlot == inventorySlot) return;
        InventorySystem.inventorySlots[orderNumber] =
            new InventorySlot(inventorySlot.ItemData, inventorySlot.StackSize);
    }

    public void AddItemToSlot(InventorySlot inventorySlot)
    {
        InventorySystem.AddItemToSpecifiedSlot(inventorySlot.ItemData, inventorySlot.StackSize, orderNumber);
    }
    public void AddItemToSlot(InventorySlot inventorySlot, int amount)
    {
        InventorySystem.AddItemToSpecifiedSlot(inventorySlot.ItemData, amount, orderNumber);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadChildrenComponent();
    }

    public void LoadChildrenComponent()
    {
        LoadInventoryUI();
        LoadIcon();
        LoadStackSizeText();
        LoadDraggableItem();
        LoadDroppedItem();
        draggableItem.LoadComponent();
        droppableItem.LoadComponent();
        ClearSlotUI();
    }
    public void SetOrderNumber(int number)
    {
        orderNumber = number;
    }
    private void LoadInventoryUI()
    {
        if(inventoryUI != null) return;
        inventoryUI = GetComponentInParent<InventoryUI>();
        Debug.LogWarning(transform.name + "LoadInventoryUI", gameObject);
    }
    private void LoadDraggableItem()
    {
        if(draggableItem != null) return;
        draggableItem = GetComponentInChildren<DraggableItem>();
        Debug.LogWarning(transform.name + "LoadDraggableItem", gameObject);
    }
    private void LoadDroppedItem()
    {
        if(droppableItem != null) return;
        droppableItem = GetComponent<DroppableItem>();
        Debug.LogWarning(transform.name + "LoadDroppedItem", gameObject);
    }
    private void LoadIcon()
    {
        if(icon != null) return;
        icon = transform.GetChild(0).GetComponent<Image>();
        Debug.LogWarning(transform.name + "LoadIcon", gameObject);
    }
    private void LoadStackSizeText()
    {
        if(stackSizeText != null) return;
        stackSizeText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + "LoadStackSizeText", gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(InventorySlot.IsEmptySlot()) return;
            if (InventorySlot.ItemData.itemType == ItemType.consumable)
            {
                PlayerCtrl.Instance.PlayerStats.SetCurrentHealth(30);
                InventorySystem.RemoveItemFromSpecifiedSlot(InventorySlot, 1);
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayerCtrl.Instance.Set(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayerCtrl.Instance.Set(false);
        InputManager.Instance.UseAttackInput();
    }
}
