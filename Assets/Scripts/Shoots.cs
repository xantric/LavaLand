using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoots : MonoBehaviour
{
    public Transform Gun;
    public float range;
    public GameObject crossHair;
    RaycastHit hit;
//    public GameObject projectile;
//    public float shootForce = 700.0f;

    // Update is called once per frame
    void Update()
    {
        crossHair.transform.position = hit.point;
        crossHair.transform.forward = -Gun.transform.forward;

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        if(Physics.Raycast(Gun.position, Gun.forward, out hit, range))
        {
            crossHair.transform.position = hit.transform.position;
        }
    }
}
