using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField name;
    public TextMeshProUGUI description;
    public TextMeshProUGUI errorMsg;
    public TextMeshProUGUI beat;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        LoadHighScore();
    }
    public void ToName()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGame()
    {
        Debug.Log(name.text);
        PlayerPrefs.SetString("newP", name.text);
        if (!PlayerPrefs.HasKey("HighScorer"))
        {
            PlayerPrefs.SetString("HighScorer", name.text);
        }
        //PlayerPrefs.Save();
        if (name.text.Length > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            errorMsg.text = "Enter your name first!";
        }
    }

    public void LoadHighScore()
    {
        string text = PlayerPrefs.GetString("HighScorer");
        int score = PlayerPrefs.GetInt("HighScore");

        description.text = text + " is the richest diver of the ocean with total coins of " + score;
        beat.text = "Can anyone beat him though? I guess not....LOL";
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoBackFromHighScore()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void GoToHelp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void GoToHighScore()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
}
