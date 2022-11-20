using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    public float enemySpeed;
    public bool turn; // untuk musuh berbalik
    void Start()
    {
        turn = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(turn){
            rb.velocity = new Vector2 (enemySpeed , rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        }else{
            rb.velocity = new Vector2 (-enemySpeed , rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        
    }

     private void OnTriggerEnter2D (Collider2D collision){
        if ( collision.gameObject.CompareTag("Turn")){
            turn = !turn;
        }
    }
}


