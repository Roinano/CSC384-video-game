using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BossState {
    BossState DoState(Boss bossState);
}
