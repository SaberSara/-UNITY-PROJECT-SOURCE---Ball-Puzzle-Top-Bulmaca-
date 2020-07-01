using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
/// <summary>
/// S
/// </summary>
public class SoundManager : MonoBehaviour
{
    
    public Sound[] sounds;
    public static SoundManager instance;

    public void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    void Start()
    {
        //NO Good sounds or time to find souhnds :)
        //play("S_BG_EENVIRONMENTMUSIC");
        //In case of specifics scenes:
        /*if ((SceneManager.GetActiveScene().name == "MainScene"))
        {
            ///
            //play("S_BG_EENVIRONMENTMUSIC");
            
           

        }*/
    }

    void Update()
    {
        
    }

    public void play(string name)
    {
        //Debug.Log("Playing sound named " + name);
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogWarning("WARNING: SOUND:" + name + "Not Found And is Skipped, Check Audio Manager if Name correct or assigned????"); }
        s.source.Play();
    }

    public void pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogWarning("WARNING: SOUND:" + name + "Not Found And is Skipped, Check Audio Manager if Name correct or assigned????"); }
        s.source.Pause();
    }

    public void stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogWarning("WARNING: SOUND:" + name + "Not Found And is Skipped, Check Audio Manager if Name correct or assigned????"); }
        s.source.Stop();
    }

    public void continuePlayWithVolume(string name, float volume)
    {
        //Debug.Log("Playing sound named " + name);
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogWarning("WARNING: SOUND:" + name + "Not Found And is Skipped, Check Audio Manager if Name correct or assigned????"); }
        if (s.source.isPlaying)
            s.source.volume = volume;
        else s.source.Play();
    }
}

