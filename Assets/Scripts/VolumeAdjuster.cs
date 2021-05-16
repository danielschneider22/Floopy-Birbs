using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeAdjuster : MonoBehaviour
{
    // volume is 0 - 11
    public int volume;
    public string playerPrefsKey;
    public GameObject bars;
    private AudioManager audioManager;
    private MusicManager musicManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        musicManager = FindObjectOfType<MusicManager>();

        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            volume = PlayerPrefs.GetInt(playerPrefsKey);
        }
        else
        {
            volume = 4;
            StoreVolumeSetting();
        }
        RedrawVolumeBars();
    }

    private void RedrawVolumeBars()
    {
        foreach (Transform child in bars.transform)
        {
            child.GetComponent<Image>().enabled = true;
        }

        for (int i = bars.transform.childCount - 1; i >= volume; i--)
        {
            bars.transform.GetChild(i).GetComponent<Image>().enabled = false;
        }
    }

    public void AddVolume()
    {
        if(volume != 11)
        {
            audioManager.Play("Click");
            volume = volume + 1;
            RedrawVolumeBars();
            StoreVolumeSetting();
            if (playerPrefsKey == "musicVolume")
            {
                SetMusicVolume();
            }
        }
    }

    public void ReduceVolume()
    {
        if(volume != 0)
        {
            audioManager.Play("Click");
            volume = volume - 1;
            RedrawVolumeBars();
            StoreVolumeSetting();
            if (playerPrefsKey == "musicVolume")
            {
                SetMusicVolume();
            }
        }
        
    }

    private void StoreVolumeSetting()
    {
        PlayerPrefs.SetInt(playerPrefsKey, volume);
    }

    private void SetMusicVolume()
    {
        musicManager.musicSource.volume = (float)volume / 11f;
    }
}
