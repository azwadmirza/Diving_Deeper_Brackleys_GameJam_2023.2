using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseGame.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu?.SetActive(true);
        Time.timeScale = 0f;
        PauseGame.isPaused = !isPaused;
    }

    public void Resume()
    {
        pauseMenu?.SetActive(false);
        Time.timeScale = 1f;
        PauseGame.isPaused = !isPaused;
    }
}
