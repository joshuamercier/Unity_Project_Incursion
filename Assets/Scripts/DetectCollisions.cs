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
        if (other.tag.Equals("Projectile") && !gameObject.tag.Equals("Obstacle"))
        {
            // Destroy the projectile object
            Destroy(other.gameObject);
            // Feed food to the animal
            // gameObject.GetComponent<AnimalHunger>().FeedAnimal(1);
        }
        else if (other.tag.Equals("Player") && gameObject.tag.Equals("Obstacle"))
        {
            // Decrease lives then announce lives remaining
            gameManager.AddLives(-1);
            // Destroy this object
            Destroy(gameObject);
            // Check if game over when lives hit 0
            gameManager.CheckGameOver();
        }

    }
}
