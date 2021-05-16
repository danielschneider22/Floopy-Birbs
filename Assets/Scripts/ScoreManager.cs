using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreTest;

    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        highScoreTest.gameObject.SetActive(false);
    }
    public void addToScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        
        if(score > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", score);
            highScoreTest.gameObject.SetActive(true);
        }
        
    }

    public void resetHighScore()
    {
        PlayerPrefs.SetInt("score", 0);
    }
}
