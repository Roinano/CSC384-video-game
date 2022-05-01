using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFaster : Item {

    public override void PerformAction() {
        player.level++;
        if (player.level == 1) {
            StateData.fireFrequency *= 0.5f;
        }
    }

}
