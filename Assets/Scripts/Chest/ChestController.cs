using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    private Animator anim;
    public bool isOpen;

    public void Awake()
    {

    }
    public void Start()
    {
        anim = GetComponent<Animator>();

    }
    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
           
            anim.SetBool("Terbuka" , isOpen);
            Debug.Log("Chest is Open");
        }
    }

    public void CloseChest(){

    }
}
