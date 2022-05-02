using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class LeaderboardManager {
    private static Leaderboard lb;

    public static void GenerateLeaderboard() {
        if (!File.Exists(Application.persistentDataPath +
            "/leaderboard.dat")) {
            Debug.Log("Not exist");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
                "/leaderboard.dat", FileMode.Create);
            Leaderboard nlb = new Leaderboard();
            bf.Serialize(file, nlb);
            file.Close();
        }
        lb = Load();
    }

    public static void Save(int score, string pn) {
        lb = Load();
        lb.AddToLeaderboard(score, pn);
        SaveBoard(lb);
    }

    public static Leaderboard Load() {
        if (File.Exists(Application.persistentDataPath +
            "/leaderboard.dat")) {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
                "/leaderboard.dat", FileMode.Open);
            lb = (Leaderboard)bf.Deserialize(file);
            file.Close();
        }
        return lb;
    }

    public static void SaveBoard(Leaderboard lbd) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath +
            "/leaderboard.dat", FileMode.Create);
        bf.Serialize(file, lbd);
        file.Close();
    }

    public static void RemoveProfile(string pn) {
        lb = Load();
        lb.Remove(pn);
        SaveBoard(lb);
    }
}
