using System.Collections.Generic;

[System.Serializable]
public class AllPlayers {
    public List<string> allNames = new List<string>();

    public void addName(string name) {
        allNames.Add(name);
    }
}
