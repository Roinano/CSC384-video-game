[System.Serializable]
public class Player {
    public int hs;
    public string name;

    public Player(int score, string name) {
        this.hs = score;
        this.name = name;
    }
}
