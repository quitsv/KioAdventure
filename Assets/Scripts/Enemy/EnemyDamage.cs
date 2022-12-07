using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            //check to avoid null reference exception
            if (collision.GetComponent<Health>() != null)
                collision.GetComponent<Health>().TakeDamage(damage);
    }
}