using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioInit : MonoBehaviour {

	public AudioClip onButtonClick;
	public AudioClip sliderValueChanged;

	AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource> ();

		AddAudio ();
	}

	public void AddAudio() {
		Button[] buttons = GameObject.FindObjectsOfType<Button> ();
		foreach (Button btn in buttons) {
			btn.onClick.AddListener (delegate {
				AddButtonAudio();
			});	
		}

		Slider[] sliders = GameObject.FindObjectsOfType<Slider> ();
		foreach (Slider slider in sliders) {
			slider.onValueChanged.AddListener (delegate {
				AddSliderAudio(); 	
			});
		}
	}

	void AddButtonAudio() {
		audioSource.clip = onButtonClick;
		audioSource.Play ();
	}

	void AddSliderAudio() {
		audioSource.clip = sliderValueChanged;
		audioSource.Play ();
	}
}