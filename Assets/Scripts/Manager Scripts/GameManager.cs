using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Class variables
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hullText;

    private float xRange = 75.0f;       // Boundary of X-axis destruction
    private float yUpperRange = 75.0f;  // boundary of lower Y-axis destruction
    private float yLowerRange = -15.0f; // boundary of lower Y-axis destruction
    private int gameScore = 0;
    private int playerHull = 100;

    // Properties
    public float BoundaryX
    {
        get { return xRange; } // getter returns backing field
    }

    public float BoundaryYUpper
    {
        get { return yUpperRange; } // getter returns backing field
    }

    public float BoundaryYLower
    {
        get { return yLowerRange; } // getter returns backing field
    }

    // Start is called before the first frame update
    void Start()
    {
        hullText.text = "Hull: " + playerHull;
        scoreText.text = "Score: " + gameScore;
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
            scoreText.text = "Score: " + gameScore;
        }

    }

    // Method for adding/decreasing player hull
    public void AddHull(int amount)
    {
        playerHull += amount;
        // Check that player hasnt already finished the game
        if (playerHull > 0)
        {
            hullText.text = "Hull: " + playerHull;
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
