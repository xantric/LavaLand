using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float movespeed = 0.5f;
    public float stopdistance = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // If the enemy is far enough from the player, move towards the player
        if (distance > stopdistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * movespeed * Time.deltaTime;
        }
    }
}
