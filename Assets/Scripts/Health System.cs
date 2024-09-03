using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    float health;
    public float damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    void OnCollisionEnter(Collision other)
    {
        health -= damage;
        if(health <= 0)
        {
            //GameOver
        }
    }
}
