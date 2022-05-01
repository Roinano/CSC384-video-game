using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    protected float health;
    protected int score;
    protected int attackCharge = 0;

    private bool destroyable;
    private EnergyBar eb;
    private float laserTimer = 0;

    void Start() {
        destroyable = false;
        Initialize();
    }

    void Update() {
        Movement();
        Shooting();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlayerBullet") {
            health--;
        }
        eb = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBar>();
        eb.AddEnergy(attackCharge);
        if (health <= 0) {
            if (other.tag == "PlayerBullet") {
                ScoreCounter.score += this.score;
            }
            if (Battle.chargable) {
                eb.AddEnergy(25);
            }
            Battle.enemyDestroyed++;
            print(Battle.enemyDestroyed);
            BattleSoundManager.playSound("ed");
            Destroy(gameObject);
        } else {
            BattleSoundManager.playSound("eh");
        }
    }

    void OnBecameVisible() {
        destroyable = true;
    }

    void OnBecameInvisible() {
        if (destroyable) {
            Destroy(gameObject);
            Battle.enemyMissed = true;
        }
    }

    public void TakeLaserDamage() {
        laserTimer -= Time.deltaTime;
        if (laserTimer <= 0) {
            health -= 0.5f;
            laserTimer = 0.05f;

            if (health <= 0) {
                ScoreCounter.score += this.score;

                Battle.enemyDestroyed++;
                BattleSoundManager.playSound("ed");
                Destroy(gameObject);
            } else {
                BattleSoundManager.playSound("eh");
            }
        }
    }

    public abstract void Movement();
    public abstract void Shooting();
    public abstract void Initialize();
}
