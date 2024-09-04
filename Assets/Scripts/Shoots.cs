using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoots : MonoBehaviour
{
    public Transform arCamera;
    public float speed = 100;
    RaycastHit hit;
    public AudioSource audioSource;
    public AudioClip shootAudio;
    public GameObject tip;
    public ARPlacements placements;
    public TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        tip.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            tip.SetActive(true);
            audioSource.PlayOneShot(shootAudio);
            Invoke("Clear", 1);
            if(Physics.Raycast(arCamera.position, arCamera.forward, out hit))
            {
                float t = hit.distance / speed;
                Invoke("Shoot", t);
            }
        }
        
    }

    void Clear()
    {
        tip.SetActive(false);
    }
    void Shoot()
    {
        Destroy(hit.transform.gameObject);
        placements.enemiesDestroyed++;
        textMeshProUGUI.text = placements.enemiesDestroyed.ToString();
    }
}
