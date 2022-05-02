public class PlayerNormalState : PlayerState {

    public PlayerState DoState(PlayerStateController player) {
        if (StateData.dead) {
            return new PlayerDeadState();
        } else {
            player.Controller();
            if (StateData.invincible || Battle.blastMode) {
                return new PlayerInvincibleState();
            }
            return this;
        }
    }
}
