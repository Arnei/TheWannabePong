using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerPrefsInit : MonoBehaviour {

	public AudioMixer mixer;
	public Slider masterSlider;
	public Slider soundEffectsSlider;
	public Slider musicSlider;

	// Use this for initialization
	void Awake () {
		// Load last resolution if it exists
		Screen.SetResolution (PlayerPrefs.GetInt("resWidth", 800),
			PlayerPrefs.GetInt("resHeight", 600), 
			PlayerPrefs.GetInt("resFullscreen", 0) == 1 ? true : false
		);

		// Get PlayerPref or Default Values for the sliders
		float defaultMasterVolume;
		float defaultSoundEffectsVolume;
		float defaultMusicVolume;
		mixer.GetFloat ("MasterVolume", out defaultMasterVolume);
		mixer.GetFloat ("SoundEffectsVolume", out defaultSoundEffectsVolume);
		mixer.GetFloat ("MusicVolume", out defaultMusicVolume);
		float masterVolume = PlayerPrefs.GetFloat ("MasterVolume", defaultMasterVolume);
		float soundEffectsVolume = PlayerPrefs.GetFloat ("SoundEffectsVolume", defaultSoundEffectsVolume);
		float musicVolume = PlayerPrefs.GetFloat ("MusicVolume", defaultMusicVolume);

		// Set Sliders
		masterSlider.value = masterVolume;
		mixer.SetFloat ("MasterVolume", masterVolume);
		soundEffectsSlider.value = soundEffectsVolume;
		PlayerPrefs.SetFloat ("SoundEffectsVolume", soundEffectsVolume);
		musicSlider.value = musicVolume;
		mixer.SetFloat ("MusicVolume", musicVolume);
	}
	

}
