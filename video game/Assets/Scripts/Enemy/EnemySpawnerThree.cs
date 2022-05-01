using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerThree : Spawner {
    public GameObject enemyType;


    public override void Initialize() {
        float rand = Random.Range(-1, 1);
        if (rand >= 0) {
            hspeed = -2;
        } else {
            hspeed = 2;
        }
        vspeed = -2;
        enemy = enemyType;
        mode = "up";
        type = 2;
    }
}
