using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorInteractable : MonoBehaviour
{

  private bool isInRange;
  public GameObject boss;
  private Health bossHealth;
  private bool bossIsDead = false;
  public KeyCode interactKey;
  public UnityEvent interactAction;

  // Start is called before the first frame update
  void Start()
  {
    bossHealth = boss.GetComponent<Health>();
  }

  // Update is called once per frame
  void Update()
  {
    bossIsDead = bossHealth.isDead();

    if (isInRange && bossIsDead)
    {
      if (Input.GetKeyDown(interactKey))
      {
        interactAction.Invoke();
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      isInRange = true;
      Debug.Log("Player now in Range");
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      isInRange = false;
      Debug.Log("Player now not in Range");
    }
  }
}