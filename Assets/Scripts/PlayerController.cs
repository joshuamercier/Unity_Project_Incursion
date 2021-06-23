using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Class variables
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    public GameObject projectilePrefab;
    
    private float xRange = 24.0f;  // Boundary of player X-axis
    private float zRange = 23.0f;  // boundary of player Z-axis
    private float fireRate = 0.5f; // Fire rate for player to shoot
    private float lastShot = 0.0f; // Last shot fired
   
    // Start is called before the first frame update
    void Start()
    {

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
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        // Keep player in lower boundary
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
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
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    void Fire()
    {
        if(Time.time > fireRate + lastShot)
        {
            // Fire projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            lastShot = Time.time;
        }
    }
}

