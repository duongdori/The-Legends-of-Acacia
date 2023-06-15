using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "SO/ItemData")]
public class ItemData : ScriptableObject
{
        public int itemID;
        public string itemName;
        public Sprite itemIcon;
        public ItemType itemType;
        public int maxStackSize = 1;
        public bool isStackable = false;
        public int dropChance;
}