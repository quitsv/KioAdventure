using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class IdleAnimation : MonoBehaviour
  {
      public GameObject item;
      public float speed;
  
      public void Update()
      {
          float y = Mathf.PingPong(Time.time * speed, 1) * 2;
          item.transform.position = new Vector3(0, y, 0);
      }
  }
