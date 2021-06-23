using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Class variables
    private int gameScore = 0;
    private int playerHull = 100;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hull: " + playerHull);
        Debug.Log("Score: " + gameScore);
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Method for adding/decreasing score
    public void AddScore(int amount)
    {
        // Check that player has not died
        if(playerHull > 0)
        {
            gameScore += amount;
            Debug.Log("Score: " + gameScore);
        }

    }

    // Method for adding/decreasing player hull
    public void AddHull(int amount)
    {
        playerHull += amount;
        // Check that player hasnt already finished the game
        if (playerHull > 0)
        {
            Debug.Log("Hull: " + playerHull);
        }
    }

    public void CheckGameOver()
    {
        if (playerHull <= 0)
        {
            Debug.Log("Game Over!");
        }
    }

    // Properties for variables
    public int Score
    {
        get => gameScore;
        set => gameScore = value;
    }

    public int Hull
    {
        get => playerHull;
        set => playerHull = value;
    }
}
