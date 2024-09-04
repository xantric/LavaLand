using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacements : MonoBehaviour
{
    [System.Serializable]
    public class WaveContent
    {
        [SerializeField][NonReorderable] GameObject[] monsterSpawner;
        [SerializeField]
        int timeBetweenEnemySpawns;
        [SerializeField]
        int numberOfEnemyToSpawn;
        public GameObject[] GetMonsterSpawnList()
        {
            return monsterSpawner;
        }
        public int getTimeBetweenSpawns()
        {
            return timeBetweenEnemySpawns;
        }
        public int getnumberOfEnemy()
        {
            return numberOfEnemyToSpawn;
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
    int waveCounter;
    IEnumerator SpawnWavesWithDelay()
    {
        maxWaves = waves.Length;
        for(int i = 0; i < maxWaves; i++)
        {
            for(int j = 0; j < waves[i].getnumberOfEnemy(); j++)
            {
                int random = Random.Range(0, waves[i].GetMonsterSpawnList().Length);
                Spawn(waves[i].GetMonsterSpawnList()[random], i+1);
                waveCounter = i + 1;
                yield return new WaitForSeconds(waves[i].getTimeBetweenSpawns());
            }
        }
        
    }

    public void Spawn(GameObject obj, int wave)
    {
        textMeshProUGUI.text = "Wave spawned: " + wave.ToString() + "/4";
        Vector3 spawnposition = FindSpawnLoc(spawnLocation);
        GameObject fireflies = Instantiate(obj, spawnposition, Quaternion.identity);
        spawnedPrefabs.Add(fireflies);
    }
    

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
            else if(enemy == null && waveCounter == 4)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

}