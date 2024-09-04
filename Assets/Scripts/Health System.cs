using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    float health;
    float t = 0;
    public float damage = 20;
    float length, width;
    public GameObject healthBar;
    public CameraShake cameraShake;
    public ARPlacements placements;
    // Start is called before the first frame update
    void Start()
    {
        t = 0 ;
        length = healthBar.GetComponent<Image>().rectTransform.rect.width / 100;
        width = 25;
        health = 100;
        damage = 20;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            health -= damage;
            Destroy(other.gameObject);
            placements.enemiesDestroyed++;
            
        }
        

    }
    void Update()
    {
        t += Time.deltaTime;

        healthBar.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(length*health, width) ;
        if (health <= 0)
        {
            //game lost
            SceneManager.LoadScene(3);
        }
    }
}
