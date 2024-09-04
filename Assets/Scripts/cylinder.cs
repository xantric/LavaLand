using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinder : MonoBehaviour
{
    float t = 0f;
    public GameObject Cylinder;
    public GameObject arCamera;
    void Start()
    {
        t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t > 120)
        {
            //game won
        }
        if(t>60 && t%5 == 0)
        {
            Instantiate(Cylinder, arCamera.transform.position, Quaternion.identity);
        }
    }
}
