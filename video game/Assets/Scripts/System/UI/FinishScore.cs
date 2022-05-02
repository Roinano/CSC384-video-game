using UnityEngine;
using UnityEngine.UI;

public class FinishScore : MonoBehaviour {
    public Text scoreText;
    public Text highScoreText;
    public Text renewText;
    public bool blink;
    public bool visible;
    public float blinkingFreq = 0.2f;
    public float timer = 0f;

    void Start() {
        scoreText.text = "Score: " + DataPassingController.playScore;
        LeaderboardManager.Save(DataPassingController.playScore, DataPassingController.playerName);
        if (DataPassingController.playScore > DataPassingController.playerHighestScore) {
            DataPassingController.playerHighestScore = DataPassingController.playScore;
            PlayerPersistence.CheckSave(DataPassingController.playScore, DataPassingController.playerName);
            //blinking effect
            blink = true;
        } else {
            blink = false;
        }
        visible = true;
        highScoreText.text = "High score: " + DataPassingController.playerHighestScore;
        CheckAchievements();
    }

    void Update() {
        if (blink) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                timer = blinkingFreq;
                if (visible) {
                    renewText.text = "";
                    visible = false;
                } else if (!visible) {
                    renewText.text = "High score renewed!";
                    visible = true;
                }

            }
        }
    }

    public void CheckAchievements() {
        if (DataPassingController.playScore >= 10000) {
            AchievementsManager.AddAchievement(DataPassingController.playerName, "Ace");
        }
        if (Battle.bossDead) {
            AchievementsManager.AddAchievement(DataPassingController.playerName, "Terminator");
        }
        if (Battle.bossDead && !Battle.dead) {
            AchievementsManager.AddAchievement(DataPassingController.playerName, "BeyondTheLight");
        }
    }
}
