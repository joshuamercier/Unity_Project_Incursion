using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Class variables
    public GameObject[] enemyPrefabs;             // Array of enemies
    public GameObject[] obstaclesPrefabs;         // Array of obstacles

    private float spawnRangeTopX = 66.0f;         // Range of spawn for X coordiante top
    private float spawnRangeTopY = 74.0f;         // Range of spawn for Z coordiante top

    private float spawnRangeSideX = 74.0f;        // Range of spawn for X coordiante sides
    private float spawnRangeSideUpY = 68.0f;      // Range of spawn for UP Y coordiante sides
    private float spawnRangeSideLowY = 9.0f;      // Range of spawn for LOWER Y coordiante sides

    private float startDelay = 2.0f;              // Seconds of delay for enemy spawning to begin
    private float spawnInterval = 1.5f;           // Seconds between each enemy spawn

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemy()
    {
        // Index of enemy to spawn
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        // Random vector3 location for enemy to be spawned at
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeTopX, spawnRangeTopX), spawnRangeTopY);
        // Creates random enemy from the random index, places this enemy in the random spawn location, and uses the enemy prefab rotation as default
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }

    void SpawnRandomObstacle()
    {
        // Index of obstacle to spawn
        int obstacleIndex = Random.Range(0, obstaclesPrefabs.Length);
        // Random vector3 location for obstacle to be spawned at
        Vector3 spawnPos = new Vector3(-spawnRangeSideX, Random.Range(-spawnRangeSideLowY, spawnRangeSideUpY));
        // Creates random obstacle from the random index, places this obstacle in the random spawn location, and uses the obstacle prefab rotation as default
        Instantiate(obstaclesPrefabs[obstacleIndex], spawnPos, obstaclesPrefabs[obstacleIndex].transform.rotation);
    }
}