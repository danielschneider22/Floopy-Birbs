using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettingsMenu : MonoBehaviour
{
    public GameObject SettingsMenu;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void ToggleSettings()
    {
        audioManager.Play("Click");
        if (SettingsMenu.activeSelf)
        {
            SettingsMenu.SetActive(false);
        } else
        {
            SettingsMenu.SetActive(true);
        }
    }
}
