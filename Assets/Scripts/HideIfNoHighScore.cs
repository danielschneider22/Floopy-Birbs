using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideIfNoHighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("score");
        if(score == 0)
        {
            highScoreText.transform.parent.gameObject.SetActive(false);
        } else
        {
            highScoreText.text = score.ToString();
        }
    }
}
