using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory_UI : MonoBehaviour
{

    public GameObject inventoryPanel;
    
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)){
            ToggleInventory();
        }
    }

    public void ToggleInventory(){
        if(!inventoryPanel.activeSelf){
            inventoryPanel.SetActive(true);
        }else{
            inventoryPanel.SetActive(false);
        }
    }
}
