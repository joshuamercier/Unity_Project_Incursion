using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Class variables
    public float xVelocity, yVelocity;

    private Material material;
    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Get material of background
        material = GetComponent<Renderer>().material;
        // Set offset
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
