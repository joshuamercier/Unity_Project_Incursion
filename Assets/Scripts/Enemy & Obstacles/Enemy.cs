using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC_Object
{
    // Class variables
    protected int scoreValue = 5;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Projectile"))
        {
            // "Destroy" the projectile object
            other.gameObject.SetActive(false);
            // Destroy enemy ship
            DestroyObject();
            gameManager.AddScore(scoreValue);
        }
        else if (other.tag.Equals("Player"))
        {
            // Decrease hull then announce hull remaining
            gameManager.AddHull(damageAmount);
            // Destroy this object
            Destroy(gameObject);
            // Check if game over when hull hit 0
            gameManager.CheckGameOver();
        }
    }
}
