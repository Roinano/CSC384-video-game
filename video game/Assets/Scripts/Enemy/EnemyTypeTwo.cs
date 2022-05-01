using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeTwo : Enemy {
    
    public float vspeed = 0;
    public float hspeed = 0;
    public GameObject bullet1;
    public GameObject bullet2;
    private float fireFrequency = 1.5f;
    private float timer = 0;
    private float changePoint;

    public override void Movement() {
        if (transform.position.y <= changePoint) {
            Vector3 move = new Vector3(hspeed, 0, 0);
            transform.Translate(move * Time.deltaTime);
        } else {
            Vector3 move = new Vector3(0, vspeed, 0);
            transform.Translate(move * Time.deltaTime);
        }
    }

    public override void Shooting() {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            timer = fireFrequency;
            Vector3 centre = transform.rotation * new Vector3(0, -0.5f, 0);
            float rand = Random.Range(1, 3);
            print(rand);
            if (rand >= 2) {
                Instantiate(bullet1, transform.position + centre, transform.rotation);
            } else {
                Instantiate(bullet2, transform.position + centre, transform.rotation);
            }
            
        }
    }

    public override void Initialize() {
        health = 3;
        score = 500;
        changePoint = Random.Range(0, 2);
    }

    public override void DeadAnimation() {
        Destroy(gameObject);
    }
}
