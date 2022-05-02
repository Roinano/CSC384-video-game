using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour {
    public AudioMixer SEmixer;

    void Start() {
        SEmixer.SetFloat("SEvol", Mathf.Log10(PlayerPrefs.GetFloat("SE")) * 20);
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }

    public void Replay() {
        SceneManager.LoadScene(1);
    }
}
