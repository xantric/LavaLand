using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoots : MonoBehaviour
{
    public Transform arCamera;
    RaycastHit hit;
    public GameObject projectile;
    public float shootForce = 700.0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            GameObject bullet = Instantiate(projectile, arCamera.position, arCamera.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward*shootForce);
            Shoot();
        }
        
    }

    void Shoot()
    {
        if(Physics.Raycast(arCamera.position, arCamera.forward, out hit))
        {
            //
        }
    }
}
