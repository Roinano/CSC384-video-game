using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPage : MonoBehaviour {
    public Text nameBox;
    public Dropdown dropdown;
    private string nameSelected;

    public Button trophy1;
    public Button trophy2;
    public Button trophy3;

    public Sprite normalTrophy;
    public Sprite goldTrophy;

    public GameObject dialogue;
    public Text achievementDetail;

    private Achievement achievement;

    void Awake() {
        dropdown = transform.GetComponent<Dropdown>();

        initialList();
        foreach (var name in AchievementsManager.Load().playerNames) {
            print(name);
        }
    }

    void Start() {
        DropdownItemSelected(dropdown.value);
        dropdown.onValueChanged.AddListener(delegate {
            DropdownItemSelected(dropdown.value);
        });
    }

    public void DropdownItemSelected(int index) {
        nameSelected = (string)dropdown.options[index].text;
        if (index == 0) {
            nameBox.text = "---";
            achievement = null;
            trophy1.GetComponent<Image>().sprite = normalTrophy;
            trophy2.GetComponent<Image>().sprite = normalTrophy;
            trophy3.GetComponent<Image>().sprite = normalTrophy;
        } else {
            nameBox.text = nameSelected;
            achievement = AchievementsManager.Load().GetAchievement(nameSelected);
            print(achievement.ace);
            if (achievement.ace) {
                trophy1.GetComponent<Image>().sprite = goldTrophy;
            } else {
                trophy1.GetComponent<Image>().sprite = normalTrophy;
            }

            if (achievement.terminator) {
                trophy2.GetComponent<Image>().sprite = goldTrophy;
            } else {
                trophy2.GetComponent<Image>().sprite = normalTrophy;
            }

            if (achievement.beyondTheLight) {
                trophy3.GetComponent<Image>().sprite = goldTrophy;
            } else {
                trophy3.GetComponent<Image>().sprite = normalTrophy;
            }
        }
    }

    public void initialList() {
        clearList();
        dropdown.options.Add(new Dropdown.OptionData() { text = "-- Select a player --" });
        List<string> items = new List<string>();

        foreach (var name in PlayerPersistence.GetAllProfiles()) {
            if (name.name != "") {
                items.Add(name.name);
            }
        }

        foreach (var item in items) {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }
    }

    public void refreshList() {
        clearList();
        initialList();
        dropdown.RefreshShownValue();
        dropdown.value = dropdown.value - 1;
        DropdownItemSelected(dropdown.value);
    }

    public void clearList() {
        dropdown.options.Clear();
    }

    public void firstOption() {
        DropdownItemSelected(0);
    }

    public string getNameSelected() {
        return nameSelected;
    }

    public void AceClicked() {
        dialogue.SetActive(true);
        achievementDetail.text = AchievementsManager.Load().aceCondition;
    }

    public void TerminatorClicked() {
        dialogue.SetActive(true);
        achievementDetail.text = AchievementsManager.Load().terminatorCondition;
    }

    public void btlClicked() {
        dialogue.SetActive(true);
        if (achievement != null) {
            if (achievement.beyondTheLight) {
                achievementDetail.text = AchievementsManager.Load().aceCondition;
            } else {
                achievementDetail.text = "???????";
            }
        } else {
            achievementDetail.text = "???????";
        }
    }
}
