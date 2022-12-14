using System;
using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using Inventory.UI;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private InventoryMenu inventoryMenu;
        [SerializeField] private InventorySO inventoryData;

        [SerializeField]
        AudioClip dropClip;

        [SerializeField]
        AudioSource audioSource;

        public List<InventoryItem> initialItems = new List<InventoryItem>();

        public void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        private void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryChanged += UpdateInventoryUI;
            foreach (InventoryItem item in initialItems)
            {
                if (item.IsEmpty)
                    continue;
                inventoryData.AddItem(item);
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            inventoryMenu.ResetAllItems();
            foreach (var item in inventoryState)
            {
                inventoryMenu.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
            }
        }

        private void PrepareUI()
        {
            inventoryMenu.InitializeInventoryUI(inventoryData.Size);
            this.inventoryMenu.OnDescriptionRequested += HandleDescriptionRequest;
            this.inventoryMenu.OnSwapItems += HandleSwapItems;
            this.inventoryMenu.OnStartDragging += HandleDragging;
            this.inventoryMenu.OnItemActionRequested += HandleItemActionRequest;
        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                inventoryMenu.ResetSelection();
                return;
            }
            ItemSO item = inventoryItem.item;
            inventoryMenu.UpdateDescription(itemIndex, item.ItemImage, item.Name, item.Description);
        }


        private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
        {
            inventoryData.SwapItems(itemIndex_1, itemIndex_2);
        }

        private void HandleDragging(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                inventoryMenu.ResetSelection();
                return;
            }
            inventoryMenu.CraeteDraggedItem(inventoryItem.item.ItemImage, inventoryItem.quantity);
        }

        private void HandleItemActionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                return;
            }
            else
            {
                IItemAction itemAction = inventoryItem.item as IItemAction;
                if (itemAction != null)
                {

                    inventoryMenu.ShowItemAction(itemIndex);
                    inventoryMenu.AddAction(itemAction.ActionName, () => PerformAction(itemIndex));
                }
            }

            IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
            if (destroyableItem != null)
            {
                inventoryMenu.AddAction("Discard", () => DropItem(itemIndex, inventoryItem.quantity));
            }

        }

        public void PerformAction(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                return;
            }
            else
            {
                IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
                if (destroyableItem != null)
                {
                    inventoryData.RemoveItem(itemIndex, 1);
                }
            }

            IItemAction itemAction = inventoryItem.item as IItemAction;
            if (itemAction != null)
            {
                itemAction.PerformAction(gameObject);
                // audioSource.PlayOneShot(itemAction.actionSFX);
                if (inventoryData.GetItemAt(itemIndex).IsEmpty)
                {
                    inventoryMenu.ResetSelection();
                }
            }

        }

        private void DropItem(int itemIndex, int quantity)
        {
            inventoryData.RemoveItem(itemIndex, quantity);
            inventoryMenu.ResetSelection();
            audioSource.PlayOneShot(dropClip);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (inventoryMenu.isActiveAndEnabled)
                {
                    inventoryMenu.Hide();
                }
                else
                {
                    inventoryMenu.Show();
                    foreach (var item in inventoryData.GetCurrentInventoryState())
                    {
                        inventoryMenu.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
                    }
                }
            }
        }
    }
}