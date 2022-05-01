using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShooting : MonoBehaviour {
    public GameObject bullet;
    private float fireFrequency = 0.3f;
    private float timer = 0;

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timer <= 0) {
            timer = fireFrequency;
            Vector3 centre = transform.rotation * new Vector3(0.14f, 0.5f, 0);
            //Vector3 centre = transform.rotation * new Vector3(0f, 0f, 0);
            Instantiate(bullet, transform.position + centre, transform.rotation);
            BattleSoundManager.playSound("ps");
        }
    }

    public void Powerup() {
        fireFrequency = 0.01f;
        Debug.Log("Shoot faster");
    }
}
