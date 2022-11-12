using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
  [SerializeField] private float attackCooldown;
  public Animator animator;
  private PlayerMovement playerMovement;
  private float cooldownTimer = Mathf.Infinity;

  //titik attack dari player
  public Transform attackPoint;
  //Layer yang bisa di attack
  public LayerMask enemyLayers;
  //Range buat nentuin jarak attack
  private float attackRange = 1;
  //damage yang di berikan
  public int attackDamage = 40;


  void Awake()
  {
    animator = GetComponent<Animator>();
    playerMovement = GetComponent<PlayerMovement>();
  }
  void Update()
  {
    //ketika player menekan klik kiri mouse
    if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
      //player akan melakukan attack
      Attack();

    cooldownTimer += Time.deltaTime;
  }

  void Attack()
  {
    //player melakukan attack
    animator.SetTrigger("meleeAttack");
    // detect enemy yang di dalam range
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    //looping untuk mengecek setiap enemy yang di temukan
    foreach (Collider2D enemy in hitEnemies)
    {
      //setiap enemy yang terkena attack akan berkurang healthnya
      enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
    }
  }

  //fungsi untuk menampilkan range attack
  void OnDrawGizmosSelected()
  {
    if (attackPoint == null)
      return;
    //menampilkan range attack
    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
  }
}
