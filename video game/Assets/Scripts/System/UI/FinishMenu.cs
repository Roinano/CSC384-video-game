using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour {
    public AudioMixer SEmixer;
    public Animator animator;

    void Start() {
        SEmixer.SetFloat("SEvol", Mathf.Log10(PlayerPrefs.GetFloat("SE")) * 20);
    }

    public void BackToMenu() {
        StartCoroutine(ChangeScene(0));
    }

    public void Replay() {
        StartCoroutine(ChangeScene(1));
    }

    IEnumerator ChangeScene(int sceneNum) {
        animator.SetTrigger("FinishSwitch");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneNum);
    }
}
