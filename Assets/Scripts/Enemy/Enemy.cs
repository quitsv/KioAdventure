using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Animator animator;

  //set health enemy
  public int maxHealth = 100;
  public int currentHealth;

  void Start()
  {
    //set current health enemy sama dengan max health
    currentHealth = maxHealth;
  }

  //fungsi untuk mengurangi health
  public void TakeDamage(int damage)
  {
    //kurangi health
    currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

    //tampilkan animasi hit
    //cek apakah health masih lebih dari 0
    if (currentHealth > 0)
    {
      animator.SetTrigger("hit");
    }
    else
    {
      //jika tidak, matikan enemy
      Die();
    }
  }

  void Die()
  {
    GetComponent<LootBag>().InstantiateLoot(transform.position);
    //animasi mati  
    animator.SetBool("die", true);

    //disable enemy tetapi tidak menghilang dari scene
    GetComponent<Collider2D>().enabled = false;
    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    this.enabled = false;
  }
}
