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

    private float spawnInterval = 1.5f;           // Seconds between each enemy spawn
    private float checkRadius = 3f;               // Radius to check for collider overlaps
    private int maxSpawnAttempts = 10;            // Max attempts to spawn to prevent infinite looping

    // Coroutines
    private IEnumerator coSpawnRandomEnemy, coSpawnRandomObstacle;

    // Start is called before the first frame update
    void Start()
    {
        coSpawnRandomEnemy = SpawnRandomEnemyOrObstacle("Enemy");
        coSpawnRandomObstacle = SpawnRandomEnemyOrObstacle("Obstacle");

        StartCoroutine(coSpawnRandomEnemy);
        StartCoroutine(coSpawnRandomObstacle);
    }

    IEnumerator SpawnRandomEnemyOrObstacle(string objectType)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            int objectIndex = Random.Range(0, enemyPrefabs.Length);     // Index of enemy to spawn
            bool validPosition = true;                                  // Boolean flag to decide whether or not we can spawn in this position
            int spawnAttempts = 0;                                      // How many times we've attempted to spawn this obstacle
            Vector3 spawnPos = Vector3.zero;                            // Spawn position vector3

            do
            {
                // Increment spawn attempts
                spawnAttempts++;
                // Get a random Vector3 position for spawn within spawn boundaries, then check if location is valid for spawn...
                if (objectType == "Enemy")
                {
                    spawnPos = new Vector3(Random.Range(-spawnRangeTopX, spawnRangeTopX), spawnRangeTopY);
                    validPosition = CheckLocationValid("Enemy", spawnPos);
                }
                else if(objectType == "Obstacle"){
                    spawnPos = new Vector3(-spawnRangeSideX, Random.Range(-spawnRangeSideLowY, spawnRangeSideUpY));
                    validPosition = CheckLocationValid("Obstacle", spawnPos);
                } 
            } while (!validPosition && spawnAttempts < maxSpawnAttempts);

            // If we exited the loop with a valid position
            if (validPosition)
            {
                // Spawn object at location
                if (objectType == "Enemy")
                {
                    Instantiate(enemyPrefabs[objectIndex], spawnPos, enemyPrefabs[objectIndex].transform.rotation);
                }
                else if (objectType == "Obstacle")
                {
                    Instantiate(obstaclesPrefabs[objectIndex], spawnPos, obstaclesPrefabs[objectIndex].transform.rotation);
                }
            }
        }
    }

    // This method takes in two parameters, the tag to check against and the spawn position Vector coordinates to check at.
    // Returns bool true or false if location is acceptable for spawning
    bool CheckLocationValid(string objectTag, Vector3 spawnPos)
    {
        // Collect all object colliders within our Obstacle Check Radius
        Collider[] colliders = Physics.OverlapSphere(spawnPos, checkRadius);

        // Go through each object collider collected
        foreach (Collider col in colliders)
        {
            // If this collider is tagged with the object tag...
            if (col.tag == objectTag)
            {
                // ...then this position is not a valid spawn position
                return false;
            }
        }
        // ...otherwise return true
        return true;
    }
}
