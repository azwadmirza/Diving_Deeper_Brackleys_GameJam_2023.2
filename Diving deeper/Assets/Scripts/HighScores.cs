using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI[] highScores;
    void Start()
    {
        highScores[0].text = PlayerPrefs.GetInt("High Score 1", 0).ToString();
        highScores[1].text = PlayerPrefs.GetInt("High Score 2", 0).ToString();
        highScores[2].text = PlayerPrefs.GetInt("High Score 3", 0).ToString();
        highScores[3].text = PlayerPrefs.GetInt("High Score 4", 0).ToString();
        highScores[4].text = PlayerPrefs.GetInt("High Score 5", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        highScores[0].text = PlayerPrefs.GetInt("High Score 1", 0).ToString();
        highScores[1].text = PlayerPrefs.GetInt("High Score 2", 0).ToString();
        highScores[2].text = PlayerPrefs.GetInt("High Score 3", 0).ToString();
        highScores[3].text = PlayerPrefs.GetInt("High Score 4", 0).ToString();
        highScores[4].text = PlayerPrefs.GetInt("High Score 5", 0).ToString();
    }

    public void AddHighScore(int highScore)
    {
        List<int> scores = new List<int>
        {
        PlayerPrefs.GetInt("High Score 1", 0),
        PlayerPrefs.GetInt("High Score 2", 0),
        PlayerPrefs.GetInt("High Score 3", 0),
        PlayerPrefs.GetInt("High Score 4", 0),
        PlayerPrefs.GetInt("High Score 5", 0),
        highScore
    };
        scores.Sort();
        scores.Reverse();
        if (scores.Count > 5)
        {
            scores.RemoveRange(5,scores.Count-5);
        }
        this.Save(scores);
    }

    private void Save(List<int>scores)
    {
        PlayerPrefs.SetInt("High Score 1", scores[0]);
        PlayerPrefs.SetInt("High Score 2", scores[1]);
        PlayerPrefs.SetInt("High Score 3", scores[2]);
        PlayerPrefs.SetInt("High Score 4", scores[3]);
        PlayerPrefs.SetInt("High Score 5", scores[4]);
        highScores[0].text = PlayerPrefs.GetInt("High Score 1", 0).ToString();
        highScores[1].text = PlayerPrefs.GetInt("High Score 2", 0).ToString();
        highScores[2].text = PlayerPrefs.GetInt("High Score 3", 0).ToString();
        highScores[3].text = PlayerPrefs.GetInt("High Score 4", 0).ToString();
        highScores[4].text = PlayerPrefs.GetInt("High Score 5", 0).ToString();
    }
}
