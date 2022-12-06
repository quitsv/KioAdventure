using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
  [SerializeField] private Image itemImage;
  [SerializeField] private TMP_Text quantityText;
  [SerializeField] private Image borderImage;

  public event Action<InventoryItem> OnItemClicked, onItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseClick;
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

  public void OnBeginDrag()
  {
    if (empty) return;
    OnItemBeginDrag?.Invoke(this);
  }

  public void OnDrop()
  {
    onItemDroppedOn?.Invoke(this);
  }

  public void OnEndDrag()
  {
    OnItemEndDrag?.Invoke(this);
  }

  public void OnPointerClick(BaseEventData data)
  {
    if (empty) return;
    PointerEventData pointerData = (PointerEventData)data;
    if (pointerData.button == PointerEventData.InputButton.Left)
    {
      OnItemClicked?.Invoke(this);
    }
    else if (pointerData.button == PointerEventData.InputButton.Right)
    {
      OnRightMouseClick?.Invoke(this);
    }
  }

}
