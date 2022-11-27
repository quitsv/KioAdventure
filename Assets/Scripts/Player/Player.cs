using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryMechanics inventory; 

    private void Awake(){
        inventory = new InventoryMechanics(8);
    }
     
}
