using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static int winningScore = 7;
    public static string difficulty = "Easy"; 

    public TMP_InputField scoreInputField;
    public TMP_Dropdown difficultyDropdown;

    private void Start()
    {
        Debug.Log("MenuManager started. Default winningScore: " + winningScore + ", Default difficulty: " + difficulty);
    }

    public void StartGame()
    {
        //convert the input field's text to an integer and update the winningScore
        int inputScore;
        if(int.TryParse(scoreInputField.text, out inputScore) && inputScore > 0)
        {
            PlayerPrefs.SetInt("WinningScore", inputScore);
            winningScore = inputScore;
            Debug.Log("Winning score set to: " + inputScore);
        }
        else
        {
            PlayerPrefs.SetInt("WinningScore", 7);
        }
        
        //load the game scene and pass the selected difficulty level as a parameter
        SceneManager.LoadScene("Pong");
        PlayerPrefs.SetString("Difficulty", difficultyDropdown.options[difficultyDropdown.value].text);

    }

}
