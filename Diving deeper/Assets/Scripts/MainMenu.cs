using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene("Tileset", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Debug.Log("Quits Game");
        Application.Quit();
    }
}
