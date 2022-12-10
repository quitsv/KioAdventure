using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    private Animator anim;
    public bool isOpen;

    public bool isTaken = false;
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

            anim.SetBool("Terbuka", isOpen);
            Debug.Log("Chest is Open");
        }


        //drop item when chest open 
        if (gameObject.CompareTag("Chest"))
        {
            if (!isTaken)
            {
               GetComponent<LootBag>().InstantiateLoot((transform.position + new Vector3(0, 0.8f, 0)));
               isTaken = true;
            }
        }


    }


}
