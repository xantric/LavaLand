using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Transform objectTofollow;
    public float moveSpeed = 0.5f;
    public float stopDistance = 0.04f;
    bool shouldMove = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, objectTofollow.position);

        // If the enemy is far enough from the player, move towards the player
        if (distance > stopDistance && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !shouldMove)
        {
            Vector3 direction = (objectTofollow.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.fixedDeltaTime;
        }
    }
}
