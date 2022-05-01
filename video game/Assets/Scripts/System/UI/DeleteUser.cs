using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteUser : MonoBehaviour
{
    public Text playerName;
    // Start is called before the first frame update
    public void Selected()
    {
        print(DataPassingController.playerName);
        playerName.GetComponent<Text>().text = DataPassingController.playerName + "?";
    }

    public void Delete() {
        PlayerPersistence.DeleteProfile(DataPassingController.playerName);
        LeaderboardManager.RemoveProfile(DataPassingController.playerName);
        AchievementsManager.RemoveProfile(DataPassingController.playerName);
    }
}
