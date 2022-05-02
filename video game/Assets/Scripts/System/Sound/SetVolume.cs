using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour {
    public AudioMixer mixer;

    public void setVolume(float sliderValue) {
        mixer.SetFloat("BGMvol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("BGM", sliderValue);
    }
}
