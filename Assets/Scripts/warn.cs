using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warn : MonoBehaviour
{
    float t = 0;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        player = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
       t += Time.deltaTime;
       if(t >= 2)
       {
            if((transform.position.x-player.transform.position.x)*(transform.position.x-player.transform.position.x)+(transform.position.y-player.transform.position.y)*(transform.position.y-player.transform.position.y) <= 1)
            {
                //game lost
            }
            Destroy(gameObject);
       } 
    }
}
