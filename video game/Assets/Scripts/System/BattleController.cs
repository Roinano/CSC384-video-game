using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {
    public Text numLifes;
    private EnergyBar eb;
    private BossHPbar bhp;
    private bool streakUp;
    private bool done;

    void Start() {
        Battle.lifes = 5f;
        Battle.energy = 0f;
        Battle.spawnTimeCD = 2.5f;
        Battle.enemyMissed = false;
        Battle.enemyDestroyed = 0;
        Battle.dead = false;
        Battle.bossDead = false;
        Battle.boss = false;
        Battle.streak = 1;

        streakUp = false;
        done = false;
        eb = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBar>();
        eb.ResetBar();
        bhp = GameObject.FindGameObjectWithTag("BossHPbar").GetComponent<BossHPbar>();
        bhp.ResetBar();
        UpdateLife();
    }

    public void UpdateLife() {
        numLifes.text = "x " + Battle.lifes;
        if (Battle.enemyDestroyed % 10 != 0) {
            done = false;
        }
        if (Battle.enemyDestroyed % 10 == 0 && !done && Battle.enemyDestroyed != 0) {
            streakUp = true;
        }
        
        if (streakUp) {
            Battle.streak += 0.1f;
            streakUp = false;
            done = true;
        }
    }

    void Update() {
        UpdateLife();
    }
}
