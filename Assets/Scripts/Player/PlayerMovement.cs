using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private float speed;
  [SerializeField] private LayerMask groundLayer;
  private Rigidbody2D body;
  private Animator anim;
  private BoxCollider2D boxCollider;
  private float horizontalInput;

  private void Awake()
  {
    //ambil reference dari komponen Rigidbody2D dan Animator
    body = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    boxCollider = GetComponent<BoxCollider2D>();
  }

  private void Update()
  {
    horizontalInput = Input.GetAxis("Horizontal");
    body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

    // flip player sprite when moving left or right
    if (horizontalInput > 0)
    {
      transform.localScale = new Vector3(10, 10, 10);
    }
    else if (horizontalInput < 0)
    {
      transform.localScale = new Vector3(-10, 10, 10);
    }

    if (Input.GetKey(KeyCode.Space))
    {
      Jump();
    }

    // set animation
    anim.SetBool("run", isMoving());
    anim.SetBool("grounded", isGrounded());
  }

  private void Jump()
  {
    if (isGrounded())
    {
      body.velocity = new Vector2(body.velocity.x, speed);
      anim.SetTrigger("jump");
    }
  }

  private bool isGrounded()
  {
    RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
    return raycastHit.collider != null;
  }

  public bool canAttack() {
    return isGrounded();
  }

  public bool isMoving() {
    return horizontalInput != 0;
  }
}