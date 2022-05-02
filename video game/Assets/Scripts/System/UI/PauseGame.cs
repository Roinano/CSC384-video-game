using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    public static bool gamePaused;
    public GameObject pauseMenuUI;

    void Start() {
        gamePaused = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        EnergyBar eb = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBar>();
        eb.ResumeBar();
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        EnergyBar eb = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBar>();
        eb.StopBar();
    }

    public void ToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame () {
        Application.Quit();
    }
}
