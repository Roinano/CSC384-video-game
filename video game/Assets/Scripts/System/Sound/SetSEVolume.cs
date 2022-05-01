using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetSEVolume : MonoBehaviour {
    public AudioMixer mixer;

    public void setVolume(float sliderValue) {
        mixer.SetFloat("SEvol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SE", sliderValue);
    }
}
