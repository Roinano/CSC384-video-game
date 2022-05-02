using UnityEngine;
using UnityEngine.UI;

public class StreakBar : MonoBehaviour {
    public Text streakBar;

    void Start() {
        streakBar = GetComponent<Text>();
    }

    void Update() {
        streakBar.text = "x " + Battle.streak;
    }
}
