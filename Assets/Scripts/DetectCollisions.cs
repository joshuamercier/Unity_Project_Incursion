using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Class variables
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Projectile") && gameObject.tag.Equals("Enemy"))
        {
            // Destroy the projectile object
            Destroy(other.gameObject);
            // Destroy enemy ship
            Destroy(gameObject);
            gameManager.AddScore(5);
            // gameObject.GetComponent<AnimalHunger>().FeedAnimal(1);
        }
        else if(other.tag.Equals("Projectile") && gameObject.tag.Equals("Obstacle"))
        {
            // Destroy the projectile object
            Destroy(other.gameObject);
            // Destroy obstacle
            Destroy(gameObject);
        }
        else if (other.tag.Equals("Player") && (gameObject.tag.Equals("Obstacle") || gameObject.tag.Equals("Enemy")))
        {
            // Decrease hull then announce hull remaining
            gameManager.AddHull(-1);
            // Destroy this object
            Destroy(gameObject);
            // Check if game over when hull hit 0
            gameManager.CheckGameOver();
        }

    }
}
