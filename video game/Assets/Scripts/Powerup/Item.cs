using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {
    protected PlayerStateController player;
    protected GameObject powerUp;

    void Update() {
        transform.position -= new Vector3(0,1,0) * 2f * Time.deltaTime;
    }

    void OnTriggerEnter2D() {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>();
        BattleSoundManager.playSound("pu");
        PerformAction();
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    public abstract void PerformAction();
}
