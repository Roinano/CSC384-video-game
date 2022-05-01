using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
    public GameObject enemyType;

    private void Update() {
        if (Battle.enemyDestroyed >= 5 && !Battle.boss) {
            Instantiate(enemyType, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Battle.boss = true;
        }
    }
}