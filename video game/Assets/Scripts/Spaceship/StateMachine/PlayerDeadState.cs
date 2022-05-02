using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeadState : PlayerState {

    public PlayerState DoState(PlayerStateController player) {
        StateData.dead = true;
        if (!StateData.deadCalled) {
            Dead(player);
        }
        return new PlayerInvincibleState();
    }

    public void Dead(PlayerStateController player) {
        StateData.deadCalled = true;
        player.fire.enabled = false;
        Battle.lifes = Battle.lifes - 1;
        BattleSoundManager.playSound("pd");
        player.gameObject.layer = 11;

        if (Battle.lifes <= 0) {
            player.StartCoroutine(checkLife(SceneManager.GetActiveScene().buildIndex + 1, player));
        } else {
            player.animator.SetBool("Dead", true);
            Battle.streak = 1;
            if (!Battle.chargable) {
                player.eb.ResetBar();
            }
            player.DestroyAfterAnimation(player.animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    IEnumerator checkLife(int sceneLevel, PlayerStateController player) {
        player.animator.SetTrigger("Dead");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
