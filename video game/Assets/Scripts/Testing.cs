using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : Enemy {

    public float vspeed = 0;
    public float hspeed = 0;
    public GameObject bullet1;
    public GameObject bullet2;
    private float fireFrequency = 1.5f;
    private float timer = 0;
    private float changePoint;

    public override void Movement() {
    }

    public override void Shooting() {
    }

    public override void Initialize() {
        health = 100;
        score = 100;
        changePoint = Random.Range(0, 2);
    }
}
