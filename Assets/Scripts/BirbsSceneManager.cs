using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirbsSceneManager : MonoBehaviour
{
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void PlayGame()
    {
        audioManager.Play("Whistle");
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
