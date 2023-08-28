using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Endmessage;
    public Player player;
    public Rigidbody2D playerRb;
    private LifeManager lifeManager;
    private BackgroundSlider slider;
    private BackgroundMove backgroundMove;
    private BackgroundMove backgroundMove1;
    private GameObject gameManager;
    private bool calledOnce;
    public static bool gameOverFlag;
    [SerializeField]private TextMeshProUGUI coinText;
    [SerializeField]private GameObject gameOver;
    void Start()
    {
        lifeManager = FindObjectOfType<LifeManager>().GetComponent<LifeManager>();
        gameManager = lifeManager.gameObject;
        calledOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = Player.numberOfCoins.ToString();
        if(lifeManager.count == 5)
        {
            PlayerPrefs.SetInt("Score", Player.numberOfCoins);
            //PlayerPrefs.Save();
            gameOverFlag = true;
            gameOver.SetActive(true);
            if(!calledOnce)
            {
                calledOnce = true;
                SendMessage();
            }
            slider = gameManager.GetComponent<BackgroundSlider>();
            backgroundMove = slider.background.GetComponent<BackgroundMove>();
            backgroundMove1 = slider.getBackground().GetComponent<BackgroundMove>();

            backgroundMove.enabled = false;
            backgroundMove1.enabled = false;
            playerRb.isKinematic = false;
            player.enabled = false;
            gameManager.SetActive(false);
        }
    }

    public void Retry()
    {
        Player.numberOfCoins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SendMessage()
    {
        int score = PlayerPrefs.GetInt("Score");
        int highScore = PlayerPrefs.GetInt("HighScore");
        string message;
        string highScorerName = PlayerPrefs.GetString("HighScorer");
        if (score > highScore)
        {
            string name = PlayerPrefs.GetString("newP");

            PlayerPrefs.SetInt("HighScore", score);

            message = "Congratulations!!! You have beaten " + highScorerName + ". Celebrate till it lasts.";
            PlayerPrefs.SetString("HighScorer", name);
        }
        else
        {
            message = "Oopsiee! You couldn't beat " + highScorerName + ". Gonna cry?!";
        }

        Endmessage.text = message;
    }
}
