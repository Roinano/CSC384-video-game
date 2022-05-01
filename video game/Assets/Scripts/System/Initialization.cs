using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPersistence.GenerateSlots();
        LeaderboardManager.GenerateLeaderboard();
        AchievementsManager.GenerateAchievements();
    }
}
