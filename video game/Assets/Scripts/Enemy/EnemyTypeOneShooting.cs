using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeOneShooting : MonoBehaviour {
    public GameObject bullet;
    private float fireFrequency = 1f;
    private float timer = 0;

    void Update() {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            timer = fireFrequency;
            Vector3 centre = transform.rotation * new Vector3(0, -0.5f, 0);
            Instantiate(bullet, transform.position + centre, transform.rotation);
        }
    }
}
