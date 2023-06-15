using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryUI : MyMonoBehaviour
{
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private List<SlotUI> slotUIList;
    public List<SlotUI> SlotUIList => slotUIList;

    public InventorySystem InventorySystem => inventorySystem;
    private void OnEnable()
    {
        InventorySystem.OnInventoryChange += UpdateInventorySlot;
    }
    private void OnDisable()
    {
        InventorySystem.OnInventoryChange -= UpdateInventorySlot;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInventorySystem();
        LoadSlotPrefab();
    }
    
    [ContextMenu("CreateSlotUI")]
    private void CreateSlotUI()
    {
        if(slotPrefab == null) return;
        DestroySlotUI();
        slotUIList = new List<SlotUI>();
        for (int i = 0; i < inventorySystem.size; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, transform);
            newSlot.TryGetComponent<SlotUI>(out SlotUI slot);
            slot.LoadChildrenComponent();
            slot.SetOrderNumber(i);
            slotUIList.Add(slot);
        }
    }
    private void DestroySlotUI()
    {
        if(transform.childCount <= 0) return;
        GameObject[] slotToRemove = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            slotToRemove[i] = transform.GetChild(i).gameObject;
        }

        for (int j = 0; j < slotToRemove.Length; j++)
        {
            DestroyImmediate(slotToRemove[j]);
        }
    }

    private void UpdateInventorySlot(List<InventorySlot> inventory)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            slotUIList[i].UpdateSlotUI(inventory[i]);
        }
    }
    
    private void LoadInventorySystem()
    {
        if(inventorySystem != null) return;
        inventorySystem = FindObjectOfType<InventorySystem>().GetComponent<InventorySystem>();
        Debug.LogWarning(transform.name + "LoadInventorySystem", gameObject);
    }
    private void LoadSlotPrefab()
    {
        if(slotPrefab != null) return;
        slotPrefab = Resources.Load<GameObject>("Prefabs/Slot");
        Debug.LogWarning(transform.name + "LoadSlotPrefab", gameObject);
    }
}
