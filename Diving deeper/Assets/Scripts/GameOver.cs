using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField]private GameObject gameOver;
    void Start()
    {
        lifeManager = FindObjectOfType<LifeManager>().GetComponent<LifeManager>();
        gameManager = lifeManager.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
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
}
