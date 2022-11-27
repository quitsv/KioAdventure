using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot: ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;

    public CollectibleType type;
    //constructor
    public Loot(string lootName , int dropChance , CollectibleType type){
        this.lootName = lootName;
        this.dropChance = dropChance;
        this.type = type;
    }

}
