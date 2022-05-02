using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class AchievementsManager {
    public static Achievements achm;

    public static void GenerateAchievements() {
        if (!File.Exists(Application.persistentDataPath +
            "/achievements.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
                "/achievements.dat", FileMode.Create);
            string[] names = new string[10];
            for (int i = 0; i < 10; i++) {
                names[i] = PlayerPersistence.GetAllProfiles()[i].name;
            }
            Achievements ach = new Achievements(names, new bool[10], new bool[10], new bool[10]);
            bf.Serialize(file, ach);
            file.Close();
        }
    }

    public static void AddAchievement(string pn, string type) {
        achm = Load();
        achm.AddAchievement(pn, type);
        SaveAchievement(achm);
    }

    public static Achievements Load() {
        if (File.Exists(Application.persistentDataPath +
            "/achievements.dat")) {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
                "/achievements.dat", FileMode.Open);
            achm = (Achievements)bf.Deserialize(file);
            file.Close();
        }
        return achm;
    }

    public static void SaveAchievement(Achievements ach) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath +
            "/achievements.dat", FileMode.Create);
        bf.Serialize(file, ach);
        file.Close();
    }

    public static void NewProfile(string pn) {
        achm = Load();
        achm.AddPlayer(pn);
        SaveAchievement(achm);
    }

    public static void RemoveProfile(string pn) {
        achm = Load();
        achm.RemovePlayer(pn);
        SaveAchievement(achm);
    }
}
