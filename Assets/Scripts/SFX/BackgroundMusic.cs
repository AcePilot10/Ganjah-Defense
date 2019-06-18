using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip soundTrack;

    private void Start()
    {
        float volume;
        if (PlayerPrefs.HasKey("Volume"))
        {
            volume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            volume = 0.1f;
            PlayerPrefs.SetFloat("Volume", volume);
            PlayerPrefs.Save();
        }
        audioSource.volume = volume;
        audioSource.loop = true;
        audioSource.clip = soundTrack;
        audioSource.Play();
    }

    private void Update()
    {
        float volume = PlayerPrefs.GetFloat("Volume");
        if (audioSource.volume != volume) audioSource.volume = volume;
    }
}