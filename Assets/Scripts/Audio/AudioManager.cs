using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    private AudioSource source;

	void Awake() {
		instance = this;
	}

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    //public void SetVolume() {
    //	if (PlayerPrefs.HasKey ("MainVolume") && PlayerPrefs.HasKey ("MusicVolume")) {
    //		float mainVolume = PlayerPrefs.GetFloat ("MainVolume");
    //		float musicVolume = PlayerPrefs.GetFloat ("MusicVolume");
    //		source.volume = mainVolume;
    //		backgroundMusicAudioSource.volume = musicVolume;
    //	}
    //}

    public void PlayAudio(AudioClip clip)
    {
        if (clip == null) return;
        source.PlayOneShot(clip);
    }
}