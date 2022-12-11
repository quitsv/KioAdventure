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
    [SerializeField] private int spearAttackDamage = 60;
    private float attackRange = 1;

    int currentWeaponNumber;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer >= attackCooldown && playerMovement.canAttack())
        {
            if (currentWeaponNumber == 0)
            {
                Attack();
            }
            else
            {
                SpearAttack();
            }
        }

        cooldownTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeWeapon();
        }

    }


    void ChangeWeapon()
    {
        if (currentWeaponNumber == 0)
        {
            currentWeaponNumber += 1;
            anim.SetLayerWeight(currentWeaponNumber - 1, 0);
            anim.SetLayerWeight(currentWeaponNumber, 1);
        }
        else
        {
            currentWeaponNumber -= 1;
            anim.SetLayerWeight(currentWeaponNumber + 1, 0);
            anim.SetLayerWeight(currentWeaponNumber, 1);
        }
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

    private void SpearAttack()
    {
        if (PauseMenu.isPaused())
            return;

        anim.SetTrigger("SpearAttack");
        cooldownTimer = 0;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(spearAttackDamage);
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
