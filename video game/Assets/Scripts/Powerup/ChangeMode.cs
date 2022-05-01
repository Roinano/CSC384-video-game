using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : Item {

    public override void PerformAction() {
        player.shootMode++;
        if (player.shootMode >= 3) {
            ScoreCounter.score += 500;
        }
    }
}
