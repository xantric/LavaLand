using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacements : MonoBehaviour
{
    [System.Serializable]
    public class WaveContent
    {
        [SerializeField][NonReorderable] GameObject[] monsterSpawner;
        public GameObject[] GetMonsterSpawnList()
        {
            return monsterSpawner;
        }
    }
    [SerializeField][NonReorderable] WaveContent[] waves;
    [SerializeField] private GameObject prefab;
    private List<GameObject> spawnedPrefabs = new List<GameObject>();
    private ARRaycastManager raycastManager;

    public Transform spawnLocation;
    float randomRange = 1f;
    int maxWaves = 3;
    public Transform playerLocation;
    public TextMeshProUGUI textMeshProUGUI;
    public float speed = 1.0f;
    public float stopDistance = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        StartCoroutine(SpawnWavesWithDelay());

    }
    IEnumerator SpawnWavesWithDelay()
    {
        while (maxWaves > 0)
        {
            spawnWave();
            maxWaves--;
            yield return new WaitForSeconds(5);
        }
        
    }

    

    //void ARRaycasting(Vector2 pos)
    //{
    //    List<ARRaycastHit> hits = new();

    //    if (raycastManager.Raycast(pos, hits, TrackableType.PlaneEstimated))
    //    {
    //        Pose pose = hits[0].pose;
    //        ARInstantiation(pose.position, pose.rotation);
    //    }
    //}

    //void ARInstantiation(Vector3 pos, Quaternion rot)
    //{
    //    spawnedPrefabs.Add(Instantiate(prefab, pos, rot));
    //}

    Vector3 FindSpawnLoc(Transform spawner)
    {
        Vector3 SpawnPos;
        float xLoc = Random.Range(-randomRange, randomRange) + spawner.position.x;
        float zLoc = Random.Range(-randomRange, randomRange) + spawner.position.z;
        float yLoc = spawner.position.y;

        SpawnPos = new Vector3(xLoc, yLoc, zLoc);
        Debug.Log("Found spawn location");
        return SpawnPos;
    }

    public void spawnWave()
    {
        Debug.Log("Hello");
        textMeshProUGUI.text = "Wave spawned: " + maxWaves.ToString(); 
        Vector3 spawnposition = FindSpawnLoc(spawnLocation);
        GameObject fireflies = Instantiate(prefab, spawnposition, Quaternion.identity);
        spawnedPrefabs.Add(fireflies);
    }

    public void Update()
    {
        MoveEnemiesTowardsPlayer();
    }
    void MoveEnemiesTowardsPlayer()
    {
        foreach(GameObject enemy in spawnedPrefabs)
        {
            if(enemy != null)
            {
                float distance = Vector3.Distance(enemy.transform.position, playerLocation.position);
                if (distance > stopDistance)
                {
                    Vector3 direction = (playerLocation.position - enemy.transform.position).normalized;

                    enemy.transform.position += direction * speed * Time.deltaTime;

                    // Optionally, rotate the enemy to face the player
                    enemy.transform.LookAt(new Vector3(playerLocation.position.x, enemy.transform.position.y, playerLocation.position.z));

                }
                
            }
        }
    }

}