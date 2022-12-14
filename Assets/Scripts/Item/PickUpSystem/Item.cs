using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;

public class Item : MonoBehaviour
{
  [field: SerializeField]
  public ItemSO InventoryItem { get; set; }

  [field: SerializeField]
  public int Quantity { get; set; } = 1;

  [field: SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private float duration = 0.2f;

  public void Start()
  {
    GetComponent<SpriteRenderer>().sprite = InventoryItem.ItemImage;
  }

  public void DestroyItem()
  {
    GetComponent<SpriteRenderer>().enabled = false;
    StartCoroutine(AnimateItemPickup());
  }

  private IEnumerator AnimateItemPickup()
  {
    audioSource.Play();
    Vector3 startScale = transform.localScale;
    Vector3 endScale = Vector3.zero;
    float currentTime = 0;
    while (currentTime < duration)
    {
      currentTime += Time.deltaTime;
      transform.localScale = Vector3.Lerp(startScale, endScale, currentTime / duration);
      yield return null;
    }
    transform.localScale = startScale;
    Destroy(gameObject);
  }
}
