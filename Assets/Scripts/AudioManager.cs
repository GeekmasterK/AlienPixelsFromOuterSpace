using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

    public static AudioManager audioManager;

    public Sound[] sounds;

	// Use this for initialization
	void Awake ()
    {
        // Check if the audio manager is null
        if (audioManager == null)
        {
            // If it is null, make sure it persists and initialize it
            DontDestroyOnLoad(gameObject);
            audioManager = this;
        }
        // Otherwise, if this audio manager is a duplicate...
        else if (audioManager != this)
        {
            // Destroy the duplicate audio manager
            Destroy(gameObject);
            return;
        }

        // Loop through the sounds array
        foreach(Sound s in sounds)
        {
            // Initialize the components of the audio source
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Play a sound by name
    public void Play(string name)
    {
        // Find the sound to play by name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check to see if the sound is null
        if(s == null)
        {
            // If the sound is null, log a warning and exit the function
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }

        // Play the sound
        s.source.Play();
    }

    // Stop playing a looping sound by name
    public void Stop(string name)
    {
        // Find the sound to stop by name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check to see if the sound is null
        if (s == null)
        {
            // If the sound is null, log a warning and exit the function
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }

        // Stop the sound
        s.source.Stop();
    }

    // Pause a looping sound by name
    public void Pause(string name)
    {
        // Find the sound to pause by name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check to see if the sound is null
        if (s == null)
        {
            // If the sound is null, log a warning and exit the function
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }

        // Pause the sound
        s.source.Pause();
    }

    // Unpause a looping sound by name
    public void UnPause(string name)
    {
        // Find the sound to unpause by name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check to see if the sound is null
        if (s == null)
        {
            // If the sound is null, log a warning and exit the function
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }

        // Unpause the sound
        s.source.UnPause();
    }
}
