using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public SpaceshipController spaceship;

    void OnTriggerEnter2D() {
        spaceship = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceshipController>();
        spaceship.Powerup();
        Destroy(gameObject);
    }
}
