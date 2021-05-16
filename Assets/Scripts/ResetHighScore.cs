using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetHighScore : MonoBehaviour
{
    private AudioManager audioManager;

    public TextMeshProUGUI highScore;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void resetHighScore()
    {
        audioManager.Play("Click");
        PlayerPrefs.SetInt("score", 0);
        if(highScore != null)
        {
            highScore.text = "0";
        }
    }
}
