using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{


    public class EquipableItemSO : ItemSO, IItemAction , IDestroyableItem
    {
        public string ActionName => "Equip";

        public AudioClip actionSFX {get; private set; }

        public bool PerformAction(GameObject character)
        {
            throw new System.NotImplementedException();
        }
    }
}