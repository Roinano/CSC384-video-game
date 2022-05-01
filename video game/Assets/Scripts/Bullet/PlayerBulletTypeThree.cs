using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletTypeThree : MonoBehaviour {
    private float maxSpeed = 10f;
    private float decayTime = 10f;
    public float rotation;

    // Update is called once per frame
    void Update() {
        Vector3 position = transform.position;
        transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        position += transform.rotation * velocity;
        transform.position = position;

        decayTime -= Time.deltaTime;
        if (decayTime <= 0) {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
    
    void OnTriggerEnter2D() {
        Destroy(gameObject);
    }
}
