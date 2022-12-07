using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
  public class InventoryItemUI : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
  {
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image borderImage;

    public event Action<InventoryItemUI> OnItemClicked, onItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseClick;
    private bool empty = true;

    public void Awake()
    {
      ResetData();
      Deselect();
    }

    public void ResetData()
    {
      this.itemImage.gameObject.SetActive(false);
      empty = true;
    }

    public void Deselect()
    {
      borderImage.enabled = false;
    }

    public void SetData(Sprite sprite, int quantity)
    {
      this.itemImage.gameObject.SetActive(true);
      this.itemImage.sprite = sprite;
      this.quantityText.text = quantity.ToString();
      empty = false;
    }

    public void Select()
    {
      borderImage.enabled = true;
    }


    public void OnPointerClick(PointerEventData pointerData)
    {
      if (pointerData.button == PointerEventData.InputButton.Left)
      {
        OnItemClicked?.Invoke(this);
      }
      else if (pointerData.button == PointerEventData.InputButton.Right)
      {
        OnRightMouseClick?.Invoke(this);
      }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
      if (empty) return;
      OnItemBeginDrag?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      OnItemEndDrag?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
      onItemDroppedOn?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
  }
}