using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected PlayerStateController player;

    void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>();
    }

    void OnTriggerEnter2D() {
        PerformAction();
        Destroy(gameObject);
    }

    protected GameObject powerUp;
    // Update is called once per frame
    protected void PlaySound() {
        BattleSoundManager.playSound("ed");
    }

    public abstract void PerformAction();
}
