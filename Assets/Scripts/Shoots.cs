using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoots : MonoBehaviour
{
    public Transform arCamera;
    RaycastHit hit;
    public GameObject projectile;
    public float shootForce = 700.0f;
    public float speed = 10f;
//    public VisualEffect vfx;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            GameObject bullet = Instantiate(projectile, arCamera.position, arCamera.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward*shootForce);
            
            if(Physics.Raycast(arCamera.position, arCamera.forward, out hit))
            {
                float t = hit.distance / speed;
  //              vfx.SendEvent("OnPlay");
                Invoke("Shoot", t);
            }
        }
        
    }

    void Shoot()
    {
            Destroy(hit.transform.gameObject);
    }
}
