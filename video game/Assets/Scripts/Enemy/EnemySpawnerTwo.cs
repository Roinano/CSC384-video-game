using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTwo : Spawner {
    public GameObject enemyType;

    public override void Initialize() {
        hspeed = -3;
        vspeed = 0;
        enemy = enemyType;
        mode = "side";
        type = 1;
    }
}
