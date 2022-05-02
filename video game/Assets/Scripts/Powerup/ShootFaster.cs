using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFaster : Item {

    public override void PerformAction() {
        player.shoot++;
        if (player.shoot == 1) {
            StateData.fireFrequency *= 0.7f;
        } else if (player.shoot == 2) {
            StateData.fireFrequency *= 0.5f;
        } else if (player.shoot >= 3) {
            ScoreCounter.score += 500;
        }
    }

}
