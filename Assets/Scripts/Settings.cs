using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings instance;

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
    }
}
