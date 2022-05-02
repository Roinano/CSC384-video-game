using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievements
{
    public string[] playerNames;
    public bool[] ace;
    public bool[] terminator;
    public bool[] beyondTheLight;

    public string aceCondition;
    public string terminatorCondition;
    public string beyondTheLightCondition;

    public Achievements(string[] playerNames, bool[] ace, bool[] terminator, bool[] beyondTheLight) {
        this.playerNames = playerNames;
        this.ace = ace;
        this.terminator = terminator;
        this.beyondTheLight = beyondTheLight;
        AchievementCondition();
    }

    public void AchievementCondition() {
        this.aceCondition = "Gained more than 10000 score in one game";
        this.terminatorCondition = "Defeated a boss";
        this.beyondTheLightCondition = "Defeated a boss and did not die in one game";
    }

    public void AddPlayer(string name) {
        for (int i = 0; i < playerNames.Length; i++) {
            if (playerNames[i] == "") {
                playerNames[i] = name;
                InitializeAchievements(i);
                break;
            }
        }
    }

    public void InitializeAchievements(int index) {
        ace[index] = false;
        terminator[index] = false;
        beyondTheLight[index] = false;
    }

    public void AddAchievement(string name, string type) {
        for (int i = 0; i < playerNames.Length; i++) {
            if (name == playerNames[i]) {
                switch (type) {
                    case "Ace":
                        ace[i] = true;
                        break;
                    case "Terminator":
                        terminator[i] = true;
                        break;
                    case "BeyondTheLight":
                        beyondTheLight[i] = true;
                        break;
                }
            }
        }
    }

    public void RemovePlayer(string name) {
        for (int i = 0; i < playerNames.Length; i++) {
            if (playerNames[i] == name) {
                playerNames[i] = null;
                InitializeAchievements(i);
                break;
            }
        }
    }

    public Achievement GetAchievement(string name) {
        Achievement a = new Achievement();
        for (int i = 0; i < playerNames.Length; i++) {
            if (playerNames[i] == name) {
                a.playerNames = playerNames[i];
                a.ace = ace[i];
                a.terminator = terminator[i];
                a.beyondTheLight = beyondTheLight[i];
                InitializeAchievements(i);
            }
        }
        return a;
    }
}

public class Achievement {
    public string playerNames;
    public bool ace;
    public bool terminator;
    public bool beyondTheLight;
}
