using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  [SerializeField] private float attackCooldown;
  private Animator anim;
  private PlayerMovement playerMovement;
  private float cooldownTimer = Mathf.Infinity;
  [SerializeField] private Transform attackPoint;
  [SerializeField] private LayerMask enemyLayers;
  [SerializeField] private int attackDamage = 40;
  private float attackRange = 1;

  private void Awake()
  {
    anim = GetComponent<Animator>();
    playerMovement = GetComponent<PlayerMovement>();
  }

  private void Update()
  {
    if (Input.GetMouseButton(0) && cooldownTimer >= attackCooldown && playerMovement.canAttack())
    {
      Attack();
    }
    cooldownTimer += Time.deltaTime;
  }

  private void Attack()
  {
    if (PauseMenu.isPaused())
      return;

    anim.SetTrigger("attack");
    cooldownTimer = 0;
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    foreach (Collider2D enemy in hitEnemies)
    {
      enemy.GetComponent<Health>().TakeDamage(attackDamage);
    }
  }

  private void OnDrawGizmosSelected()
  {
    if (attackPoint == null)
      return;
    //menampilkan range attack
    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
  }
}
