using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : NPC_Object
{
    // Class variables

    protected override void OnTriggerEnter(Collider other)
    {
        
    }

    // Override method to check if out of bounds. Game Boundary set by the GameManager. If out of bounds, object is disabled for object pooling.
    protected override void DestroyObjectWhenOutbounds()
    {
        // If an object goes past the game boundaries, remove that object
        if (transform.position.y > gameManager.BoundaryYUpper || transform.position.y < gameManager.BoundaryYLower ||
            transform.position.x > gameManager.BoundaryX || transform.position.x < -gameManager.BoundaryX)
        {
            gameObject.SetActive(false);
        }
    }

}
