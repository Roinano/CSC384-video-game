using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    public Text scoreBar;

    void Start() {
        ScoreCounter.score = 0;
        scoreBar = GetComponent<Text>();
    }

    void Update() {
        scoreBar.text = Convert.ToString(ScoreCounter.score);
        DataPassingController.playScore = ScoreCounter.score;
    }
}
