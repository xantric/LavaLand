using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterSpawneer : MonoBehaviour
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
    // Start is called before the first frame update
    [SerializeField][NonReorderable] WaveContent[] waves;
    int currentWave = 0;
    float randomRange = 1f;
    public TextMeshProUGUI text;
    bool shouldSpawn = false;
    public Transform player;
    public float movespeed = 0.5f;
    public float stopdistance = 0.3f;
    void Start()
    {
        StartCoroutine(SpawnWaveWithDelay());
    }
    IEnumerator SpawnWaveWithDelay()
    {
        while (shouldSpawn)
        {
            spawnWave();
            yield return new WaitForSeconds(10);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !shouldSpawn)
        {
            spawnWave();
            shouldSpawn = true;
        }
    }

    void spawnWave()
    {
        text.text = "Instantiation started";
        Debug.Log("Instantiation started.");
        for(int i = 0; i < waves[currentWave].GetMonsterSpawnList().Length; i++)
        {
            GameObject ene = Instantiate(waves[currentWave].GetMonsterSpawnList()[i], FindSpawnLoc(), Quaternion.identity);
            StartCoroutine(FollowPlayer(ene));
        }
        Debug.Log("Instantiated");
    }
    IEnumerator FollowPlayer(GameObject spawnedObject)
    {
        while (true)
        {
            if (spawnedObject != null)
            {
                float distance = Vector3.Distance(spawnedObject.transform.position, player.position);

                // If the spawned object is far enough from the player, move towards the player
                if (distance > stopdistance)
                {
                    Vector3 direction = (player.position - spawnedObject.transform.position).normalized;
                    spawnedObject.transform.position += direction * movespeed * Time.deltaTime;
                }
            }
        }
    }
    Vector3 FindSpawnLoc()
    {
        Vector3 SpawnPos;
        float xLoc = Random.Range(-randomRange, randomRange) + transform.position.x;
        float zLoc = Random.Range(-randomRange, randomRange) - transform.position.z;
        float yLoc = transform.position.y;

        SpawnPos = new Vector3(xLoc, yLoc, zLoc);

        return SpawnPos;
    }
}
