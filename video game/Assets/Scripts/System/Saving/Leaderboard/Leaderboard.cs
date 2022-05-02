using System;

[Serializable]
public class Leaderboard {
    public int[] best10Score;
    public string[] best10Name;
    public int[] sortedScore;
    public string[] sortedName;
    public int[] tempScores;
    public string[] tempNames;
    public int[] allScores;
    public string[] allNames;

    public int arrayLength = 10;
    public int allScoreLength;

    public Leaderboard() {
        best10Score = new int[arrayLength];
        best10Name = new string[arrayLength];

        sortedScore = new int[arrayLength];
        sortedName = new string[arrayLength];

        allScores = new int[arrayLength + 1];
        allNames = new string[arrayLength + 1];
        allScoreLength = arrayLength;
    }

    public void AddToLeaderboard(int score, string name) {
        bool checkNull = false;
        for (int i = 0; i < allScoreLength; i++) {
            if (allNames[i] == null) {
                checkNull = true;
                break;
            }
        }

        if (!checkNull) {
            allScoreLength++;
        }
        
        tempScores = new int[allScoreLength];
        tempNames = new string[allScoreLength];

        for (int i = 0; i < allScoreLength; i++) {
            int l;
            if (allScoreLength > 10) {
                l = allScoreLength - 1;
            } else {
                l = allScoreLength;
            }
            if (i < l) {
                if (allNames[i] != null) {
                    tempScores[i] = allScores[i];
                    tempNames[i] = allNames[i];
                } else {
                    tempScores[i] = -1;
                    tempNames[i] = allNames[i];
                } 
            }
        }

        allScores = new int[allScoreLength];
        allNames = new string[allScoreLength];

        allScores = tempScores;
        allNames = tempNames;

        for (int i = 0; i < allScoreLength; i++) {
            if (allNames[i] == null) {
                allNames[i] = name;
                allScores[i] = score;
                break;
            }
        }
        Array.Sort(allScores, allNames);
        Array.Reverse(allScores);
        Array.Reverse(allNames);

        for (int i = 0; i < arrayLength; i++) {
            sortedScore[i] = allScores[i];
            sortedName[i] = allNames[i];
        }
    }

    public void Remove(string name) {
        for (int i = 0; i < allNames.Length; i++) {
            if (allNames[i] == name) {
                allNames[i] = null;
                allScores[i] = -1;
            }
        }

        Array.Sort(allScores, allNames);
        Array.Reverse(allScores);
        Array.Reverse(allNames);

        for (int i = 0; i < arrayLength; i++) {
            sortedScore[i] = allScores[i];
            sortedName[i] = allNames[i];
        }
    }
}
