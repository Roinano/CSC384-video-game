using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPage : MonoBehaviour
{
    private int numOfRank = 10;

    private Text[] nameTexts;
    private Text[] scoreTexts;
    private Text[] rankTexts;

    // Start is called before the first frame update

    private void Awake() {
        RefreshBoard();
    }

    void Start()
    {
        LeaderboardManager.GenerateLeaderboard();


        RefreshBoard();
    }

    public void GetTextBoxes() {
        rankTexts = LoopForText("Ranking");
        nameTexts = LoopForText("Name");
        scoreTexts = LoopForText("Score");
    }

    public Text[] LoopForText(string name) {
        Text[] components = new Text[numOfRank];
        for (int i = 1; i <= numOfRank; i++) {
            components[i-1] = GameObject.Find(name+i).GetComponent<Text>();
        }
        return components;
    }

    public void FillLeaderboard(Leaderboard lb) {
        for (int i = 0; i < numOfRank; i++) {
            rankTexts[i].text = (i+1).ToString();
            if (lb.sortedName[i] == null) {
                nameTexts[i].text = "---";
                if (lb.sortedScore[i] <= 0) {
                    scoreTexts[i].text = "---";
                } else {
                    scoreTexts[i].text = lb.sortedScore[i].ToString();
                }
            } else {
                nameTexts[i].text = lb.sortedName[i];
                if (lb.sortedScore[i] <= 0) {
                    scoreTexts[i].text = 0.ToString();
                } else {
                    scoreTexts[i].text = lb.sortedScore[i].ToString();
                }
            }
        }
    }

    public void RefreshBoard() {
        GetTextBoxes();
        FillLeaderboard(LeaderboardManager.Load());
    }
}
