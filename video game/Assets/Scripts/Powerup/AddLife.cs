using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife : Item {

    public override void PerformAction() {
        Battle.lifes++;
    }
}
