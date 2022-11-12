using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] private float startingHealth;
  public float currentHealth { get; private set; }
  private Animator animator;
  private bool dead;

  private void Awake()
  {
    currentHealth = startingHealth;
    animator = GetComponent<Animator>();
  }
  public void TakeDamage(float damage)
  {
    currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

    if (currentHealth > 0)
    {
      animator.SetTrigger("hit");
    }
    else
    {
      if (!dead)
      {
        animator.SetTrigger("die");
        GetComponent<PlayerMovement>().enabled = false;
        dead = true;
      }
    }
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.F))
    {
      TakeDamage(10);
    }
  }
}