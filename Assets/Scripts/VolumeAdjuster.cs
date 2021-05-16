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

    private void Start()
    {
        if(PlayerPrefs.HasKey(playerPrefsKey))
        {
            volume = PlayerPrefs.GetInt(playerPrefsKey);
        } else
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
            volume = volume + 1;
            RedrawVolumeBars();
            StoreVolumeSetting();
        }
    }

    public void ReduceVolume()
    {
        if(volume != 0)
        {
            volume = volume - 1;
            RedrawVolumeBars();
            StoreVolumeSetting();
        }
    }

    private void StoreVolumeSetting()
    {
        PlayerPrefs.SetInt(playerPrefsKey, volume);
    }
}
