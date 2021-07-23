using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Class variables
    private float xRange = 75.0f; // Boundary of X-axis destruction
    private float yUpperRange = 75.0f; // boundary of lower Y-axis destruction
    private float yLowerRange = -15.0f; // boundary of lower Y-axis destruction

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If an object goes past the game boundaries, remove that object
        if (transform.position.y > yUpperRange || transform.position.y < yLowerRange || transform.position.x > xRange || transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }
    }
}
