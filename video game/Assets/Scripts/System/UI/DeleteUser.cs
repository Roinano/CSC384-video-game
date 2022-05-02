using UnityEngine;
using UnityEngine.UI;

public class DeleteUser : MonoBehaviour {
    public Text playerName;

    public void Selected() {
        print(DataPassingController.playerName);
        playerName.GetComponent<Text>().text = DataPassingController.playerName + "?";
    }

    public void Delete() {
        PlayerPersistence.DeleteProfile(DataPassingController.playerName);
        LeaderboardManager.RemoveProfile(DataPassingController.playerName);
        AchievementsManager.RemoveProfile(DataPassingController.playerName);
    }
}
