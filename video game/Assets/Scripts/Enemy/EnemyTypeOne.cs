using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeOne : Enemy {
    public float vspeed = 0;
    public float hspeed = 0;
    public GameObject bullet;
    private float fireFrequency = 1f;
    private float timer = 0;

    public override void Movement() {
        Vector3 move = new Vector3(hspeed, vspeed, 0);
        transform.Translate(move * Time.deltaTime);
    }

    public override void Shooting() {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            timer = fireFrequency;
            Vector3 centre = transform.rotation * new Vector3(0, -0.5f, 0);
            Instantiate(bullet, transform.position + centre, transform.rotation);
        }
    }

    public override void Initialize() {
        health = 1;
        score = 100;
    }

    public override void DeadAnimation() {
        Destroy(gameObject);
    }
}
