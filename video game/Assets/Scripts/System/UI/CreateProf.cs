using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateProf : MonoBehaviour
{
    public InputField textField;
    public Text warningText;
    public Text successText;

    // Start is called before the first frame update
    public void Create()
    {
        successText.GetComponent<Text>().text = "";
        warningText.GetComponent<Text>().text = "";
        PlayerPersistence.GenerateSlots();
        string name = textField.text;
        if (name.Length > 20) {
            warningText.GetComponent<Text>().text = "Name too long!!";
        } else if (name == "") {
            warningText.GetComponent<Text>().text = "Please enter a name!!";
        } else {
            if (PlayerPersistence.Availability(name)) {
                PlayerPersistence.CreateProfile(name);
                AchievementsManager.NewProfile(name);
                successText.GetComponent<Text>().text = "Success";
            } else {
                warningText.GetComponent<Text>().text = "The name is not available or the space is full.";
            }
        }
        
        //print(SavingSystem.LoadPlayer(name).name);
        foreach (var prof in PlayerPersistence.GetAllProfiles()) {
            print(prof.name);
        }
        
    }

    public void Reset() {
        warningText.GetComponent<Text>().text = "";
        successText.GetComponent<Text>().text = "";
        textField.text = "";
    }
}
