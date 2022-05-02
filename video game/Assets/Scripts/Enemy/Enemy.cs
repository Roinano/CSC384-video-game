using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    protected float health;
    protected float score;
    protected int attackCharge = 0;

    private bool destroyable;
    private EnergyBar eb;
    private float laserTimer = 0;
    private float hurtVoiceTimer = 0;
    private bool se = true;

    void Start() {
        destroyable = false;
        Initialize();
    }

    void Update() {
        Movement();
        Shooting();
        HurtCountDown();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlayerBullet") {
            health--;
        }
        eb = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBar>();
        if (Battle.chargable) {
            if (se) {
                eb.AddEnergy(attackCharge);
            }
        }
        if (health <= 0) {
            if (other.tag == "PlayerBullet") {
                ScoreCounter.score += (int)(this.score * Battle.streak);
            }
            if (Battle.chargable) {
                eb.AddEnergy(5);
            }
            Battle.enemyDestroyed++;
            print(Battle.enemyDestroyed);
            DeadAnimation();
            BattleSoundManager.playSound("ed");
            
        } else {
            if (se) {
                BattleSoundManager.playSound("eh");
                se = false;
            }
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

    public void HurtCountDown() {
        hurtVoiceTimer -= Time.deltaTime;
        if (hurtVoiceTimer <= 0) {
            se = true;
            hurtVoiceTimer = 0.1f;
        }
    }

    public void TakeLaserDamage() {
        laserTimer -= Time.deltaTime;
        if (laserTimer <= 0) {
            health --;
            laserTimer = 0.05f;

            if (health <= 0) {
                ScoreCounter.score += (int)(this.score * Battle.streak);

                Battle.enemyDestroyed++;
                print(Battle.enemyDestroyed);
                DeadAnimation();
                BattleSoundManager.playSound("ed");
            } else {
                if (se) {
                    BattleSoundManager.playSound("eh");
                    se = false;
                    ScoreCounter.score += (int)(5 * Battle.streak);
                }
            }
        }
    }

    public abstract void Movement();
    public abstract void Shooting();
    public abstract void Initialize();
    public abstract void DeadAnimation();
}
