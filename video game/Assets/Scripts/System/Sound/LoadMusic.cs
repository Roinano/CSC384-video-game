using UnityEngine;
using UnityEngine.Audio;

public class LoadMusic : MonoBehaviour {
    public AudioMixer SEmixer;
    public AudioMixer BGMmixer;

    void Start() {
        SEmixer.SetFloat("SEvol", Mathf.Log10(PlayerPrefs.GetFloat("SE")) * 20);
        BGMmixer.SetFloat("BGMvol", Mathf.Log10(PlayerPrefs.GetFloat("BGM")) * 20);
    }
}
