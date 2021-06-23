using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Class variables
    public float xRange = 40.0f; // Boundary of player X-axis
    public float zRange = 40.0f; // boundary of player Z-axis

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If an object goes past the game boundaries, remove that object
        if (transform.position.z > zRange || transform.position.z < -zRange || transform.position.x > xRange || transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }
    }
}
