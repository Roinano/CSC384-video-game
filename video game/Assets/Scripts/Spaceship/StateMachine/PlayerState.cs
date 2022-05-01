using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerState
{
    PlayerState DoState(PlayerStateController playerState);
}
