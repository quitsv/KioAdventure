
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //buat manggil function/object body
   private Rigidbody2D body;

   //biar speed ngereffer ke unitynya langsung waktu kita ganti speednya 
   [SerializeField] private float speed;

   // pas waktu dijalanin biar langsung manggil function
   private void Awake() {
    body = GetComponent<Rigidbody2D>();
   }
    
    void Update()
    {
        //buat gerak kiri kanan
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed ,body.velocity.y);

        // buat loncat 
        if(Input.GetKey(KeyCode.Backspace) || Input.GetKey(KeyCode.W)){
            body.velocity = new Vector2 (body.velocity.x , speed);
        }
    }
}
