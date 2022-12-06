using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
  [SerializeField] private InventoryItem itemPrefab;
  [SerializeField] private RectTransform contentPanel;
  [SerializeField] private InventoryDescription description;

  List<InventoryItem> listOfItems = new List<InventoryItem>();

  public Sprite image;
  public int quantity;
  public string title, desc;

  private void Awake()
  {
    Hide();
    description.ResetDescription();
  }

  public void InitializeInventoryUI(int size)
  {
    for (int i = 0; i < size; i++)
    {
      InventoryItem item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, contentPanel);
      listOfItems.Add(item);
      item.OnItemClicked += HandleItemSelection;
      item.OnItemBeginDrag += HandleBeginDrag;
      item.onItemDroppedOn += HandleSwap;
      item.OnItemEndDrag += handleEndDrag;
      item.OnRightMouseClick += HandleShowItemActions;
    }
  }

  private void HandleShowItemActions(InventoryItem obj)
  {

  }

  private void handleEndDrag(InventoryItem obj)
  {

  }

  private void HandleSwap(InventoryItem obj)
  {

  }

  private void HandleBeginDrag(InventoryItem obj)
  {

  }

  private void HandleItemSelection(InventoryItem obj)
  {
    description.SetDescription(image, title, desc);
    listOfItems[0].Select();
  }

  public void Show()
  {
    gameObject.SetActive(true);
    description.ResetDescription();
    listOfItems[0].SetData(image, quantity);
  }

  public void Hide()
  {
    gameObject.SetActive(false);
  }
}
