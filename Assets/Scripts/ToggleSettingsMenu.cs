using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettingsMenu : MonoBehaviour
{
    public GameObject SettingsMenu;

    public void ToggleSettings()
    {
        if (SettingsMenu.activeSelf)
        {
            SettingsMenu.SetActive(false);
        } else
        {
            SettingsMenu.SetActive(true);
        }
    }
}
