using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] ambiance, sfx;
    public AudioSource ambianceSource, sfxSource;

    // To call: AudioManager.Instance.PlaySFX("Whatever) or PlayAmbiance("Whatever);
    public static AudioManager Instance;

    private void Awake() 
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        
    }

    private void Start ()
    {
        PlayAmbiance("wind");
    }

    public void PlayAmbiance(string name)
    {
        Sound s = Array.Find(ambiance, x => x.name == name); 
        if(s == null){
            Debug.LogWarning("Sound: " + s + " not found !");
            return;
        }
        else
        {
            ambianceSource.clip = s.clip;
            ambianceSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfx, x => x.name == name); 
        if(s == null){
            Debug.LogWarning("Sound: " + s + " not found !");
            return;
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleAmbiance(float volume)
    {
        ambianceSource.volume = volume;
    }

    public void ToggleSFX(float volume)
    {
        sfxSource.volume = volume;
    }




// OLD !!!!
    // Start is called before the first frame update
    /*void Awake() 
    {
        foreach(Sound s in amb){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            //s.source.output = s.output;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
        
    }

    void Start ()
    {
        Play("Ambiance_Wind_Calm_Loop_Stereo");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound: " + s + " not found !");
            return;
        }
        s.source.Play();
    }

    public void SetVolumeBackground(float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Ambiance_Wind_Calm_Loop_Stereo");
        audioMixer.SetFloat("volume", s.source.volume);
        Debug.Log("Volume: " + s.source.volume);
    }
    // To play sounds, call method like this:
    // FindObjectOfType<AudioManager>().Play("Whatever sound you wanna play");
    */
}
