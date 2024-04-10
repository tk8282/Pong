using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Paddle playerPaddle;

    public Paddle ComputerPaddle;

    public MenuManager menuManager;

    public Ball ball;

    public Text playerScoreNumber;

    public Text computerScoreNumber;

    public int playerScore;

    public int computerScore;

    // Static reference to the GameManager instance
    private static GameManager instance;

    // Ensure the GameManager persists between scenes
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Ensure only one instance exists, destroy duplicates
            Destroy(gameObject);
        }
    }

    // Getter for the GameManager instance
    public static GameManager Instance
    {
        get
        {
            // If the GameManager instance hasn't been set yet, find it in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    //adds 1 to playerscore when the user scores
    public void PlayerScores()
    {
        playerScore++;
        this.playerScoreNumber.text = playerScore.ToString();
        CheckGameEnd();
        Reset();
    }
    //adds 1 to computerscore when the user scores
    public void ComputerScores()
    {
        computerScore++;
        this.computerScoreNumber.text = computerScore.ToString();
        CheckGameEnd();
        Reset();
    }

    // Method to check if the game should end
    void CheckGameEnd()
    {
        int winningScore = MenuManager.winningScore;

        Debug.Log(winningScore);

        if (playerScore >= winningScore || computerScore >= winningScore)
        {
            EndGame();
        }
    }

    // Method to end the game
    void EndGame()
    {
        // Load the end game scene
        SceneManager.LoadScene("EndMenu");
    }

    private void Reset()
    {
        this.playerPaddle.ResetPaddle();
        this.ComputerPaddle.ResetPaddle();
        this.ball.ResetBall();
        this.ball.AddStartingForce();
    }
}
