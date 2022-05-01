using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class PlayerPersistence {

    public static void GenerateSlots() {
        if (!File.Exists(Application.persistentDataPath +
            "/Profile_" + 1 + ".dat")) {
            for (int i = 1; i <= 10; i++) {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath +
                    "/Profile_" + i + ".dat", FileMode.Create);
                Player sc = new Player(0, "");
                bf.Serialize(file, sc);
                file.Close();
            }
        }
        Debug.Log("Created");
    }

    public static void CreateProfile(string pn) {
        for (int i = 1; i <= 10; i++) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
                "/Profile_" + i + ".dat", FileMode.Open);
            Player sc = (Player)bf.Deserialize(file);
            file.Close();

            if (sc.name == "") {
                FileStream cf = File.Open(Application.persistentDataPath +
                "/Profile_" + i + ".dat", FileMode.Create);
                Player pp = new Player(0, pn);

                bf.Serialize(cf, pp);
                cf.Close();
                break;
            }
            
        }
    }

    public static void CheckSave(int score, string pn) {
        for (int i = 1; i <= 10; i++) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
                "/Profile_" + i + ".dat", FileMode.Open);
            Player sc = (Player)bf.Deserialize(file);
            file.Close();

            if (sc.name == pn) {
                FileStream cf = File.Open(Application.persistentDataPath +
                "/Profile_" + i + ".dat", FileMode.Create);
                Player pp = new Player(score, pn);

                bf.Serialize(cf, pp);
                cf.Close();
                break;
            }
            
        }
    }

    public static Player Load(string pn) {
        Player pf = null;
        for (int i = 1; i <= 10; i++) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
                "/Profile_" + i + ".dat", FileMode.Open);
            Player sc = (Player)bf.Deserialize(file);
            file.Close();

            if (sc.name == pn) {
                pf = sc;
            }
        }
        return pf;
    }

    public static List<Player> GetAllProfiles() {
        List<Player> playerProfiles = new List<Player>();
        for (int i = 1; i <= 10; i++) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
                "/Profile_" + i + ".dat", FileMode.Open);
            Player sc = (Player)bf.Deserialize(file);
            

            playerProfiles.Add(sc);
            file.Close();
        }
        return playerProfiles;
    }

    public static bool Availability(string pn) {
        List<Player> pp = GetAllProfiles();
        int nullNum = 0;
        foreach (var prof in pp) {
            if (pn == prof.name) return false;
            if (prof.name != "") nullNum++;
        }
        if (nullNum == 10) {
            return false;
        }
        return true;
    }

    public static void DeleteProfile(string pn) {
        for (int i = 1; i <= 10; i++) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
                "/Profile_" + i + ".dat", FileMode.Open);
            Player sc = (Player)bf.Deserialize(file);
            file.Close();

            if (sc.name == pn) {
                FileStream cf = File.Open(Application.persistentDataPath +
                "/Profile_" + i + ".dat", FileMode.Create);
                Player pp = new Player(0, "");

                bf.Serialize(cf, pp);
                cf.Close();
                break;
            }
        }
    }
    
    public static void DeleteAllProfile() {
        for (int i = 1; i <= 10; i++) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
                "/Profile_" + i + ".dat", FileMode.Open);
            Player sc = (Player)bf.Deserialize(file);
            file.Close();
            sc.name = "";
            sc.hs = 0;
        }
    }
}
