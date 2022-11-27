using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventoryMechanics
{
    [System.Serializable]
    public class Slot
    {
        public CollectibleType type;
        public int count;
        public int maxAllowed;

        public Sprite icon;

        //constructor Slot Class
        public Slot()
        {
            type = CollectibleType.NONE;
            count = 0;
            maxAllowed = 99;
        }

        public bool CanAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(Collectibles item){
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }

    }
    public List<Slot> slots = new List<Slot>();

    //constructor InventoryMechanics Class 
    public InventoryMechanics(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }



    public void Add(Collectibles item )
    {      
        //kalo di inven ada slotnya + masih belom max
        foreach (Slot slot in slots)
        {
            if (slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        //kalo di inven kosong 
        foreach(Slot slot in slots){
            if(slot.type == CollectibleType.NONE){
                slot.AddItem(item);
                return;
            }
        }
    }

}
