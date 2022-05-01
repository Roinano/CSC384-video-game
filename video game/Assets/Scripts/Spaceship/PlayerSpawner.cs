using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject spaceship;
    private GameObject player;
    private float spawnTimeCD = 2;

    // Start is called before the first frame update
    void Start() {
        SpawnPlayer();
    }

    void SpawnPlayer() {
        player = (GameObject)Instantiate(spaceship, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update() {
        if (player == null) {
            spawnTimeCD -= Time.deltaTime;
            if (spawnTimeCD <= 0) {
                spawnTimeCD = 2;
                SpawnPlayer();
            }
        }
    }
}
