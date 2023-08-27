using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public Rigidbody2D playerRb;
    private LifeManager lifeManager;
    private BackgroundSlider slider;
    private BackgroundMove backgroundMove;
    private BackgroundMove backgroundMove1;
    private GameObject gameManager;
    [SerializeField]private TextMeshProUGUI coinText;
    [SerializeField]private GameObject gameOver;
    void Start()
    {
        lifeManager = FindObjectOfType<LifeManager>().GetComponent<LifeManager>();
        gameManager = lifeManager.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = Player.numberOfCoins.ToString();
        if(lifeManager.count == 5)
        {
            gameOver.SetActive(true);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex+1)%2);
    }
}
