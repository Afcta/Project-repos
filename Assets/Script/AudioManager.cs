using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake() 
    {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
        }
        
    }

    public void Play (string name)
    {
        Sound s .Find(sounds, sound => sound.name = name);
        if(s == null){
            Debug.LogWarning("Sound: " + s + " not found !");
            return;
        }
        s.source.Play();
    }
}
