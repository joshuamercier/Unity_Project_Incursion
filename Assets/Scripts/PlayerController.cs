using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Class variables
    private float horizontalInput;
    private float verticalInput;

    public float playerSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get player inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move player by their inputs
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerSpeed);
    }
}
