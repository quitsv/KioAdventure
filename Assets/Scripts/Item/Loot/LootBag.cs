using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;

public class LootBag : MonoBehaviour
{
  public GameObject droppedItemPrefab;
  public List<ItemSO> lootList = new List<ItemSO>();

  private ItemSO GetDroppedItem()
  {
    int randomNumber = Random.Range(1, 101); //1-100
    List<ItemSO> possibleItems = new List<ItemSO>();
    foreach (ItemSO item in lootList)
    {
      if (randomNumber <= item.DropChance)
      {
        possibleItems.Add(item);
      }
    }
    if (possibleItems.Count > 0)
    {
      ItemSO droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
			droppedItemPrefab.GetComponent<SpriteRenderer>().sprite = droppedItem.ItemImage;
      Debug.Log("dropped item: " + droppedItem.Name);
      return droppedItem;
    }
    Debug.Log("No item dropped");
    return null;
  }
  public void InstantiateLoot(Vector3 spawnPosition)
  {
    ItemSO droppedItem = GetDroppedItem();
    if (droppedItem != null)
    {
			GameObject droppedItemObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
      droppedItemObject.GetComponent<SpriteRenderer>().sprite = droppedItem.ItemImage;
      droppedItemObject.GetComponent<Item>().InventoryItem = droppedItem;
    }
  }
}
