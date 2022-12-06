using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
  [SerializeField] private InventoryMenu inventoryMenu;
  public int size = 6;

  public void Start()
  {
    inventoryMenu.InitializeInventoryUI(size);
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
      }
    }
  }
}
