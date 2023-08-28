using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public PauseGame game;
    public Player player;
    void OnEnable()
    {
        player.setCoins(0);
        game.Resume();
    }

}
