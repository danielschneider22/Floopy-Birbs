using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public VolumeAdjuster musicVolume;
    public AudioSource musicSource;
    private AudioManager audioManager;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(this);

        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        musicSource.volume = (float)musicVolume.volume / 11f;
    }

    private void Update()
    {
        if(audioManager.sounds[4].source.isPlaying)
        {
            musicSource.Pause();
        } else if (!audioManager.sounds[4].source.isPlaying && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}
