using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    public VolumeAdjuster soundVolumeAdjuster;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            DestroyImmediate(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.clip = s.clip;
        }
        DontDestroyOnLoad(this);
    }

    public void Play(string name, float distanceFromPlayer = 0f, bool looped = false)
    {
        if(distanceFromPlayer <= 2)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
                return;
            s.source.loop = looped;
            if(soundVolumeAdjuster != null)
            {
                float origVol = s.source.volume;
                float vol = (float)soundVolumeAdjuster.volume / 11f;
                s.source.volume = vol;
                s.source.Play();
                // s.source.volume = origVol;
            } else
            {
                s.source.Play();
            }
            
        }
        
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }

    public void StopAll()
    {
        foreach(Sound sound in sounds)
        {
            sound.source.Stop();
        }
    }
}
