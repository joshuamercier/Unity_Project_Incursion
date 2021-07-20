using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Class variables
    private float xRange = 70.0f; // Boundary of X-axis destruction
    private float yRange = 40.0f; // boundary of player Z-axis

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If an object goes past the game boundaries, remove that object
        if (transform.position.y > yRange || transform.position.y < -yRange || transform.position.x > xRange || transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }
    }
}
