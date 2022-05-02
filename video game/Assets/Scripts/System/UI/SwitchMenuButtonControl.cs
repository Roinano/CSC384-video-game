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

    public void select_back() {
        selectMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void select_create() {
        selectMenu.SetActive(false);
        createMenu.SetActive(true);
    }
    
    public void select_delete() {
        deleteMenu.SetActive(true);
    }

    public void create_back() {
        createMenu.SetActive(false);
        selectMenu.SetActive(true);
    }

    public void main_play() {
        mainMenu.SetActive(false);
        selectMenu.SetActive(true);
    }
    
    public void main_setting() {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    public void main_quit() {
        Application.Quit();
    }

    public void main_htp() {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void delete_back() {
        deleteMenu.SetActive(false);
    }

    public void setting_back() {
        settingMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void toLeaderboard() {
        mainMenu.SetActive(false);
        leaderboard.SetActive(true);
    }

    public void board_main() {
        leaderboard.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void main_achievement() {
        mainMenu.SetActive(false);
        achievement.SetActive(true);
    }
    public void achievement_main() {
        achievement.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void trophyDetail_back() {
        trophyDetail.SetActive(false);
    }

    public void htp_main() {
        howToPlay.SetActive(false);
        mainMenu.SetActive(true);
    }
}
