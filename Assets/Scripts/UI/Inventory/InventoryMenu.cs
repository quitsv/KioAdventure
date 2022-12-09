using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
  public class InventoryMenu : MonoBehaviour
  {
    [SerializeField] private InventoryItemUI itemPrefab;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private InventoryDescription description;
    [SerializeField] private MouseFollower mouseFollower;

    List<InventoryItemUI> listOfItems = new List<InventoryItemUI>();
    private int currentlyDraggedItemIndex = -1;
    public event Action<int> OnDescriptionRequested, OnItemActionRequested, OnStartDragging;
    public event Action<int, int> OnSwapItems;

    private void Awake()
    {
      Hide();
      mouseFollower.Toggle(false);
      description.ResetDescription();
    }

    public void InitializeInventoryUI(int size)
    {
      for (int i = 0; i < size; i++)
      {
        InventoryItemUI item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, contentPanel);
        listOfItems.Add(item);
        item.OnItemClicked += HandleItemSelection;
        item.OnItemBeginDrag += HandleBeginDrag;
        item.onItemDroppedOn += HandleSwap;
        item.OnItemEndDrag += handleEndDrag;
        item.OnRightMouseClick += HandleShowItemActions;
      }
    }

    public void UpdateData(int itemIndex, Sprite sprite, int quantity)
    {
      if (listOfItems.Count > itemIndex)
      {
        listOfItems[itemIndex].SetData(sprite, quantity);
      }
    }

    private void HandleShowItemActions(InventoryItemUI inventoryItem)
    {
       int index = listOfItems.IndexOf(inventoryItem);
      if (index == -1)
      {
        return;
      }
      OnItemActionRequested?.Invoke(index);
    }

    private void handleEndDrag(InventoryItemUI inventoryItem)
    {
      ResetDraggedItem();
    }

    private void HandleSwap(InventoryItemUI inventoryItem)
    {
      int index = listOfItems.IndexOf(inventoryItem);
      if (index == -1)
      {
        return;
      }
      OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
      HandleItemSelection(inventoryItem);
      mouseFollower.Toggle(false);
      currentlyDraggedItemIndex = -1;
    }

    private void ResetDraggedItem()
    {
      mouseFollower.Toggle(false);
      currentlyDraggedItemIndex = -1;
    }

    private void HandleBeginDrag(InventoryItemUI inventoryItem)
    {
      int index = listOfItems.IndexOf(inventoryItem);
      if (index == -1) return;
      currentlyDraggedItemIndex = index;
      HandleItemSelection(inventoryItem);
      OnStartDragging?.Invoke(index);
    }

    public void CraeteDraggedItem(Sprite sprite, int quantity)
    {
      mouseFollower.Toggle(true);
      mouseFollower.SetData(sprite, quantity);
    }

    private void HandleItemSelection(InventoryItemUI inventoryItem)
    {
      int index = listOfItems.IndexOf(inventoryItem);
      if (index == -1) return;
      OnDescriptionRequested?.Invoke(index);
    }

    public void Show()
    {
      gameObject.SetActive(true);
      ResetSelection();
    }

    public void ResetSelection()
    {
      description.ResetDescription();
      DeselectAllItems();
    }

    private void DeselectAllItems()
    {
      foreach (InventoryItemUI item in listOfItems)
      {
        item.Deselect();
      }
    }

    public void Hide()
    {
      gameObject.SetActive(false);
      ResetDraggedItem();
    }

    internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string desc)
    {
      description.SetDescription(itemImage, name, desc);
      DeselectAllItems();
      listOfItems[itemIndex].Select();
    }

    internal void ResetAllItems()
    {
      foreach (var item in listOfItems)
      {
        item.ResetData();
        item.Deselect();
      }
    }
  }
}