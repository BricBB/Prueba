using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] donaPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    void Start()
    {
            InvokeRepeating("SpawnRandomDona", startDelay, spawnInterval);
    }

    void Update()
    {
        
    }

    void SpawnRandomDona()
    {
        int dona = Random.Range(0, 3);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        Instantiate(donaPrefabs[dona], spawnPos, donaPrefabs[dona].transform.rotation);
    }
}
