using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Class variables
    public GameObject upperSpace;

    private Vector3 resetPos;
    private Vector3 posWhenReset;
    // Start is called before the first frame update
    void Start()
    {
        // Grab position to where we will reset the object to
        resetPos = upperSpace.transform.position;
        // Grab position to know when we should reset the object
        posWhenReset = new Vector3(transform.position.x, transform.position.y, -97.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= posWhenReset.z)
        {
            transform.position = resetPos;
        }
    }
}
