using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Class variables
    private int gameScore = 0;
    private int gameLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Lives: " + gameLives);
        Debug.Log("Score: " + gameScore);
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Method for adding/decreasing score
    public void AddScore(int amount)
    {
        // Check that player has not already finished the game
        if(gameLives > 0)
        {
            gameScore += amount;
            Debug.Log("Score: " + gameScore);
        }

    }

    // Method for adding/decreasing lives
    public void AddLives(int amount)
    {
        gameLives += amount;
        // Check that player hasnt already finished the game
        if (gameLives > 0)
        {
            Debug.Log("Lives: " + gameLives);
        }
    }

    public void CheckGameOver()
    {
        if (gameLives == 0)
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

    public int Lives
    {
        get => gameLives;
        set => gameLives = value;
    }
}
