using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : NPC_Object
{
    // Class variables

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Projectile"))
        {
            // "Destroy" the projectile object
            other.gameObject.SetActive(false);
            // Destroy obstacle
            DestroyObject();
        }
        else if (other.tag.Equals("Player"))
        {
            // Damage hull, then announce hull remaining
            gameManager.AddHull(damageAmount);
            // Destroy this object
            DestroyObject();
            // Check if game over when hull hit 0
            gameManager.CheckGameOver();
        }
    }
}
