using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Class variables
    public float speed;
    public GameObject projectilePrefab;

    private float horizontalInput;
    private float verticalInput;
    private float xRange = 66.0f;  // Boundary of player X-axis
    private float yUpperRange = 68.0f; // Boundary of player Y upper
    private float yLowerRange = 9.0f;  // Boundary of player Y lower
    private float fireRate = 0.5f; // Fire rate for player to shoot
    private float lastShot = 0.0f; // Last shot fired
    private Transform firePort;    // Fire port for the ship to shoot

    // Start is called before the first frame update
    void Start()
    {
        // Get gun port
        firePort = transform.Find("Gun Port");
    }

    // Update is called once per frame
    void Update()
    {
        // Check player is kept in game boundaries
        CheckBoundaries();

        // Check that player is firing
        CheckFire();

        // Check player input movement
        CheckMovement();
    }

    // Method that checks that player is inside game boundries
    void CheckBoundaries()
    {
        // Keep player in left boundary
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // Keep player in right boundary
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // Keep player in upper boundary
        if (transform.position.y > yUpperRange)
        {
            transform.position = new Vector3(transform.position.x, yUpperRange);
        }
        // Keep player in lower boundary
        if (transform.position.y < -yLowerRange)
        {
            transform.position = new Vector3(transform.position.x, -yLowerRange);
        }
    }

    // Method that checks if player is using space input to fire weapon
    void CheckFire()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }

    // Method to check player input for moving their ship
    void CheckMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
    }

    void Fire()
    {
        if (Time.time > fireRate + lastShot)
        {
            // Fire projectile from projectile pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = firePort.transform.position; // position it at player
            }
            lastShot = Time.time;
        }
    }
}
