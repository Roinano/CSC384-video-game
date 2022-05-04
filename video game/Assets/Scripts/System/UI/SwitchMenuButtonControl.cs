using System.Collections;
using UnityEngine;

public class SwitchMenuButtonControl : MonoBehaviour {
    public GameObject selectMenu;
    public GameObject createMenu;
    public GameObject deleteMenu;
    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject leaderboard;
    public GameObject achievement;
    public GameObject trophyDetail;
    public GameObject howToPlay;

    public Animator mainAnimator;
    public Animator createAnimator;
    public Animator selectAnimator;
    public Animator settingAnimator;
    public Animator achievementAnimator;
    public Animator leaderboardAnimator;

    private string mainTrigger = "MainSwitch";
    private string createTrigger = "CreateSwitch";
    private string selectTrigger = "SelectSwitch";
    private string settingTrigger = "SettingSwitch";
    private string achievementTrigger = "AchievementSwitch";
    private string leaderboardTrigger = "LeaderboardSwitch";

    public void select_back() {
        StartCoroutine(ChangeScene(selectAnimator, selectTrigger, mainMenu, selectMenu));
    }

    public void select_create() {
        StartCoroutine(ChangeScene(selectAnimator, selectTrigger, createMenu, selectMenu));
    }
    
    public void select_delete() {
        deleteMenu.SetActive(true);
    }

    public void create_back() {
        StartCoroutine(ChangeScene(createAnimator, createTrigger, selectMenu, createMenu));
    }

    public void main_play() {
        StartCoroutine(ChangeScene(mainAnimator, mainTrigger, selectMenu, mainMenu));
    }
    
    public void main_setting() {
        StartCoroutine(ChangeScene(mainAnimator, mainTrigger, settingMenu, mainMenu));
    }

    public void main_quit() {
        Application.Quit();
    }

    public void main_htp() {
        howToPlay.SetActive(true);
    }

    public void delete_back() {
        deleteMenu.SetActive(false);
    }

    public void setting_back() {
        StartCoroutine(ChangeScene(settingAnimator, settingTrigger, mainMenu,  settingMenu));
    }

    public void toLeaderboard() {
        StartCoroutine(ChangeScene(mainAnimator, mainTrigger, leaderboard, mainMenu));
    }

    public void board_main() {
        StartCoroutine(ChangeScene(leaderboardAnimator, leaderboardTrigger, mainMenu, leaderboard));
    }

    public void main_achievement() {
        StartCoroutine(ChangeScene(mainAnimator, mainTrigger, achievement, mainMenu));
    }
    public void achievement_main() {
        StartCoroutine(ChangeScene(achievementAnimator, achievementTrigger, mainMenu, achievement));
    }
    public void trophyDetail_back() {
        trophyDetail.SetActive(false);
    }

    public void htp_main() {
        howToPlay.SetActive(false);
    }

    IEnumerator ChangeScene(Animator animator, string trigger, GameObject targetMenu, GameObject originalMenu) {
        animator.SetTrigger(trigger);
        yield return new WaitForSeconds(0.5f);
        originalMenu.SetActive(false);
        targetMenu.SetActive(true);
    }
}
