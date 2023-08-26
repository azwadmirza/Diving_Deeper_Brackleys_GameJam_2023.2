using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject gameOver;
    public void PlayGame()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex +1));
    }

    public void ExitGame()
    {
        Debug.Log("Quits Game");
        Application.Quit();
    }
}
