using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public static Vector3 lastCheckpoint;
    // Start is called before the first frame update
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position =lastCheckpoint;
    }

    // Update is called once per frame
 private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            lastCheckpoint = transform.position;
            
        }
    }
}
