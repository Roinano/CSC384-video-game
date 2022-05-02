using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject spaceship;
    private GameObject player;
    private float spawnTimeCD = 2;

    void Start() {
        SpawnPlayer();
    }

    void SpawnPlayer() {
        player = (GameObject)Instantiate(spaceship, transform.position, transform.rotation);
    }

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
