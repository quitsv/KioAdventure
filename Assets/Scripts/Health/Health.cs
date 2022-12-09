using System.Collections;
using UnityEngine;
using Inventory.Model;

public class Health : MonoBehaviour
{
  [Header("Health")]
  [SerializeField] private float startingHealth;
  public float currentHealth { get; private set; }
  private Animator animator;
  private bool dead;

  [Header("iFrame")]
  [SerializeField] private float iFrameDuration;
  [SerializeField] private float numberOfFlashes;
  private SpriteRenderer spriteRenderer;

  [Header("Components")]
  [SerializeField] private Behaviour[] components;
  private bool invulnerable;

  private void Awake()
  {
    currentHealth = startingHealth;
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }
  public void TakeDamage(float damage)
  {
    if (invulnerable) return;
    currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

    if (currentHealth > 0)
    {
      animator.SetTrigger("hit");
      StartCoroutine(FlashSprite());
      Debug.Log(currentHealth);
    }
    else
    {
      if (!dead)
      {
        Die();
      }
    }
  }

  private void Die()
  {
    animator.SetTrigger("die");
    foreach (Behaviour component in components)
    {
      component.enabled = false;
    }
    dead = true;

    //drop item when enemy dies
    if (gameObject.CompareTag("Enemy"))
    {
      GetComponent<LootBag>().InstantiateLoot((transform.position + new Vector3(0, 1f, 0)));      
    }
    Destroy(gameObject, 5f);
  }

  private IEnumerator FlashSprite()
  {
    invulnerable = true;
    Physics2D.IgnoreLayerCollision(3, 7, true);
    //invunerability duration
    for (int i = 0; i < numberOfFlashes; i++)
    {
      spriteRenderer.color = new Color(1, 0, 0, 0.5f);
      yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
      spriteRenderer.color = Color.white;
      yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
    }
    Physics2D.IgnoreLayerCollision(3, 7, false);
    invulnerable = false;
  }

  private void Deactivate()
  {
    gameObject.SetActive(false);
  }

  public bool isDead()
  {
    return dead;
  }

  public void AddHealth(int value){
    
    if (currentHealth == 100){
      currentHealth = currentHealth + 0;
      Debug.Log("full health!");
    }else{
      currentHealth = currentHealth + value;
       Debug.Log(currentHealth);
    }
  
 
  // Debug.Log("ngisi darah");
  }
}