using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController1 : MonoBehaviour
{
    public bool isClicked;
    // public Lever1Pulled lever1pull;
    // public Lever1 lever1;

    public void ClickLever()
    {
        if(!isClicked)
        {
            isClicked = true;
            Debug.Log("Lever is pulled...");
            // lever1pull.setActive(true);
            // lever1.setActive(false);
        }
    }
}
