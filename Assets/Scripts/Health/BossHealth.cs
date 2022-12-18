using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    private float healthBoss;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        healthBoss = GetComponent<Health>().currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDead()
    {
        return isDead;
    }
}
