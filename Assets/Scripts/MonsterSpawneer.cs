using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawneer : MonoBehaviour
{
    [System.Serializable]
    public class WaveContent
    {
        [SerializeField][NonReorderable] GameObject[] monsterSpawner;
    }
    // Start is called before the first frame update
    [SerializeField][NonReorderable] WaveContent[] waves;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
