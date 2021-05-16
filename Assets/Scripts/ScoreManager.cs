using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreTest;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

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
            if(!highScoreTest.gameObject.activeSelf)
            {
                audioManager.Play("Ding");
            }
            highScoreTest.gameObject.SetActive(true);
        }
        
    }
}
