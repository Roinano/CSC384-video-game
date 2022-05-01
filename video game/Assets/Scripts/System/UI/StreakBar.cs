using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreakBar : MonoBehaviour
{
    public Text streakBar;
    // Start is called before the first frame update
    void Start() {
        streakBar = GetComponent<Text>();
    }

    private void Update() {
        streakBar.text = "x " + Battle.streak;
    }
}
