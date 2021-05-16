using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseGameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalHighScoreText;
    public ScoreManager scoreManager;
    public WallSpawner wallSpawner;
    public GameObject player;

    public GameObject highScoreText;

    private Vector3 initPosition;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Start()
    {
        initPosition = player.transform.position;
    }
    public void LoseGame()
    {
        gameOverCanvas.SetActive(true);
        scoreManager.scoreText.gameObject.SetActive(false);
        finalScoreText.text = "Score: " + scoreManager.score.ToString();
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        wallSpawner.shouldSpawn = false;
        foreach (Transform child in wallSpawner.transform)
        {
            child.GetComponent<MoveLeft>().enabled = false;
        }
        audioManager.Play("Honk");
        audioManager.Play("VictoryChime");

        if (highScoreText.gameObject.activeSelf)
        {
            highScoreText.SetActive(false);
            finalHighScoreText.gameObject.SetActive(true);
        }
    }

    public void Retry()
    {
        gameOverCanvas.SetActive(false);
        scoreManager.scoreText.gameObject.SetActive(true);
        scoreManager.score = 0;
        scoreManager.scoreText.text = "0";
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        wallSpawner.shouldSpawn = true;
        foreach (Transform child in wallSpawner.transform)
        {
            Destroy(child.gameObject);
        }
        player.transform.position = initPosition;
        player.transform.eulerAngles = new Vector3(0, 0, 0);

        finalHighScoreText.gameObject.SetActive(false);
    }
}
