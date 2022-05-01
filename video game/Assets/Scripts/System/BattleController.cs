using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public Text numLifes;
    private EnergyBar eb;
    private BossHPbar bhp;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("Lifes", 3f);
        //PlayerPrefs.SetFloat("Energy", 0f);
        Battle.lifes = 1000f;
        Battle.energy = 0f;
        Battle.spawnTimeCD = 2.5f;
        Battle.enemyMissed = false;
        Battle.enemyDestroyed = 0;
        Battle.dead = false;
        eb = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBar>();
        eb.ResetBar();
        bhp = GameObject.FindGameObjectWithTag("BossHPbar").GetComponent<BossHPbar>();
        bhp.ResetBar();
        UpdateLife();
    }

    public void UpdateLife() {
        numLifes.text = "x " + Battle.lifes;
        //numLifes.text = "x " + PlayerPrefs.GetFloat("Lifes");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
    }
}
