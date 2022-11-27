using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{   
    public CollectibleType type;
    public Sprite icon;
    private  void OnTriggerEnter2D(Collider2D collision){
    
        Player player = collision.GetComponent<Player>();
        
        if(player){
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }
     
}
 public enum CollectibleType{
        NONE , POTION_S , POTION_M , POTION_L 
    }