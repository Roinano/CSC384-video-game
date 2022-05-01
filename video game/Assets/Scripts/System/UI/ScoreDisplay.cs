using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreBar;
    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter.score = 0;
        scoreBar = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreBar.text = Convert.ToString(ScoreCounter.score);
        DataPassingController.playScore = ScoreCounter.score;
    }
}
