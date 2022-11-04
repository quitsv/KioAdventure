
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //buat manggil function/object body
   private Rigidbody2D body;
   private Animator anim;
   private bool grounded;
   //biar speed ngereffer ke unitynya langsung waktu kita ganti speednya 
   [SerializeField] private float speed;

   // grab refferences to rigidbody and animator from object
   private void Awake() {
    body = GetComponent<Rigidbody2D>();
    anim = GetComponent <Animator>();
   }
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //buat gerak kiri kanan
        body.velocity = new Vector2(horizontalInput*speed ,body.velocity.y);

        //buat ngeflip player kalo gerak kiri kanan
        if (horizontalInput > 0.01f){
            transform.localScale = new Vector3(10,10,10);
        }else if ( horizontalInput < -0.01f){
            transform.localScale = new Vector3(-10,10,10);
        }

        // buat loncat 
        if(Input.GetKey(KeyCode.Space) && grounded){
        Jump();

        }

        //set animation parameter
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded",grounded);
    }

    private void Jump(){
          body.velocity = new Vector2 (body.velocity.x , speed);
          anim.SetTrigger("jump");
          grounded=false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            grounded = true;
        }

    }
}
