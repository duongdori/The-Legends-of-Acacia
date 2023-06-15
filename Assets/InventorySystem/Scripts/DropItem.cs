using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropItem : MonoBehaviour
{
    public GameObject itemPrefab;
    public int amountOfItems;
    public ItemData[] possibleDrop;
    public List<ItemData> dropList = new List<ItemData>();

    private void Start()
    {
        for (int i = 0; i < possibleDrop.Length; i++)
        {
            if (Random.Range(0, 100) <= possibleDrop[i].dropChance)
            {
                dropList.Add(possibleDrop[i]);
            }
        }
    }

    public void GenerateDrop()
    {
        // for (int i = 0; i < possibleDrop.Length; i++)
        // {
        //     if (Random.Range(0, 100) <= possibleDrop[i].dropChance)
        //     {
        //         dropList.Add(possibleDrop[i]);
        //     }
        // }

        for (int i = 0; i < amountOfItems; i++)
        {
            int randomIndex = Random.Range(0, dropList.Count);
            ItemData randomItem = dropList[randomIndex];
            
            if (randomItem.itemID == 0)
            {
                int randomChance = Random.Range(0, 100);

                if (randomChance <= randomItem.dropChance)
                {
                    DropItemOnGround(randomItem);
                }
            }
            else
            {
                DropItemOnGround(randomItem);
            }
                //dropList.Remove(randomItem);
        }
    }
    
    
    public void DropItemOnGround(ItemData itemDrop)
    {
        Vector3 pos = transform.position + Vector3.right * Random.Range(-2f, 2f);
        GameObject newItem = Instantiate(itemPrefab, pos, Quaternion.identity);
        newItem.TryGetComponent(out Item item);
        item.UpdateItem(itemDrop, 1);
    }
}
