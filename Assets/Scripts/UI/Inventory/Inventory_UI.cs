using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory_UI : MonoBehaviour
{


    public Player player;
    public List<Slots_UI> slots = new List<Slots_UI>();
    public GameObject inventoryPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Setup()
    {
        if (slots.Count == player.inventory.slots.Count)
        {

            for (int i = 0; i < slots.Count; i++)
            {

                if (player.inventory.slots[i].type != CollectibleType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }
}
