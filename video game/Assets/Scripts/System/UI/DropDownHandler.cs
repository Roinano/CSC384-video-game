using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropDownHandler : MonoBehaviour {
    public Text NameBox;
    public Text ScoreBox;
    public Text CountPlayer;
    public string nameSelected;
    public int scoreSelected;
    public Dropdown dropdown;
    public Text warning;
    public Button db;

    void Awake() {
        dropdown = transform.GetComponent<Dropdown>();
        initialList();
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
            db.GetComponent<Button>().interactable = false;
            NameBox.text = "---";
            ScoreBox.text = "---";
        } else {
            db.GetComponent<Button>().interactable = true;
            scoreSelected = PlayerPersistence.Load(nameSelected).hs;
            DataPassingController.playerName = nameSelected;
            DataPassingController.playerHighestScore = scoreSelected;
            NameBox.text = nameSelected;
            ScoreBox.text = "" + scoreSelected;
        }
    }

    public void playGame() {
        if (dropdown.value == 0) {
            warning.GetComponent<Text>().text = "Please select or create a player profile!!";
        } else {
            SceneManager.LoadScene(1);
        }
    }

    public void initialList() {
        clearList();
        dropdown.options.Add(new Dropdown.OptionData() { text = "-- Select a player --" });
        List<string> items = new List<string>();

        int cp = 0;
        foreach (var name in PlayerPersistence.GetAllProfiles()) {
            if (name.name != "") {
                items.Add(name.name);
                cp++;
            }
        }
        CountPlayer.text = "Player " + cp + "/10";

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
        warning.GetComponent<Text>().text = "";
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
}
