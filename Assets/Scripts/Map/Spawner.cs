using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform enemySpawnPoint;
    public GameObject gameObj;
    private GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {

        if (Random.value > 0.1) //%90 percent chance (1 - 0.1 is 0.9) items or enemies will appear
        {
            spawn = Instantiate(gameObj, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }
        
        var spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");

        for (var i = 0; i < spawnPoint.Length; i++)
        {
            Destroy(spawnPoint[i]);
        }
    }
}
