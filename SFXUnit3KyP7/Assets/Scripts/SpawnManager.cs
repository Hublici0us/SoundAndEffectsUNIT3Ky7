using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    public float startSpawnRate = 2;
    public float SpawnRate = 1.5f;
    public float maxSpawnRate = 4f;

    private PlayerController playerControl;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startSpawnRate, Random.Range(SpawnRate,maxSpawnRate));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int obstacleArray = Random.Range(0, obstaclePrefabs.Length);

        if (playerControl.gameOver == false)
        {
            Instantiate(obstaclePrefabs[obstacleArray], spawnPos, obstaclePrefabs[obstacleArray].transform.rotation);
        }
    }
}
