using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibleState : PlayerState
{
    public PlayerState DoState(PlayerStateController player) {
        if (!StateData.dead) {
            player.Controller();
        }
        Invincible(player);
        if (!StateData.invincible) {
            return new PlayerNormalState();
        }
        return this;
    }

    public void Invincible(PlayerStateController player) {
        if (StateData.invincibleTime <= 0 && !Battle.blastMode) {
            player.animator.SetBool("Invincible", false);
            player.gameObject.layer = 6;
            StateData.invincible = false;
        } else {
            player.animator.SetBool("Invincible", true);
            player.gameObject.layer = 7;
            StateData.invincibleTime -= Time.deltaTime;
            StateData.invincible = true;
        }
    }
}
