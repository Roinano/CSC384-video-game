using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletTypeOne : MonoBehaviour {
    private float maxSpeed = 10f;
    private float decayTime = 2f;

    // Update is called once per frame
    void Update() {
        Vector3 position = transform.position;
        //transform.rotation = Quaternion.Euler(Vector3.forward * 0);
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        position += transform.rotation * velocity;
        transform.position = position;

        decayTime -= Time.deltaTime;
        if (decayTime <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D() {
        Destroy(gameObject);
    }
}
