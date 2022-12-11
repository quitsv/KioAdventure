using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
  private bool blocking;
  private bool canAttack;
  private bool moving;
  private Animator anim;
  private Health health;
  private PlayerMovement playerMovement;

  private void Awake()
  {
    blocking = false;
    anim = GetComponent<Animator>();
    health = GetComponent<Health>();
		playerMovement = GetComponent<PlayerMovement>();
  }

  private void Update()
  {
    moving = playerMovement.isMoving();
    canAttack = playerMovement.canAttack();

    if (Input.GetMouseButtonDown(1) && !moving && canAttack)
    {
      Block();
    }
    if (Input.GetMouseButtonUp(1))
      UnBlock();

  }

  private void Block()
  {
    blocking = true;
		health.SetInvulnerable(true);
    anim.SetBool("block", true);
  }

  private void UnBlock()
  {
    blocking = false;
		health.SetInvulnerable(false);
    anim.SetBool("block", false);
  }
}