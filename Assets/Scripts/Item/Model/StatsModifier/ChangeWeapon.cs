using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ChangeWeapon :  CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
       PlayerAttack changeWeapon = character.GetComponent<PlayerAttack>();
        if (changeWeapon != null)
        {
            changeWeapon.CanChangeWeapon((int)val);
        }else{
            Debug.Log("no change weapon!");
        }
        
    }
}
