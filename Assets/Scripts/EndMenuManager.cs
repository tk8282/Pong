using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    public Text playerScoreText;
    public Text computerScoreText;
    public Text winnerText;

void Start()
    {
        // Access GameManager instance and display scores
        GameManager gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found.");
            return;
        }

        // Fetch player and computer scores from GameManager
        int playerScore = gameManager.playerScore;
        int computerScore = gameManager.computerScore;

        // Display scores in the UI
        playerScoreText.text = "Player Score: " + playerScore;
        computerScoreText.text = "Computer Score: " + computerScore;

        // Determine the winner based on scores
        if (playerScore > computerScore)
        {
            winnerText.text = "Player Wins!";
        }
        else if (computerScore > playerScore)
        {
            winnerText.text = "Computer Wins!";
        }
        else
        {
            winnerText.text = "It's a Tie!";
        }
    }
    
    // Method to exit the game
    public void ExitGame()
    {
        Application.Quit(); // Exit the application
    }
}
