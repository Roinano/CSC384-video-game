using System.Collections;
using UnityEngine;

public class BossStateTwo : BossState {
    private int counter;

    public BossState DoState(Boss bossState) {
        counter = 0;
        bossState.StartCoroutine(LoopBullet(bossState));
        return null;
    }

    IEnumerator LoopBullet(Boss boss) {
        yield return new WaitForSeconds(0.03f);
        boss.BulletRandom();
        boss.Bullet2Random();
        counter++;
        if (boss.atLocation3) {
            boss.StartCoroutine(LoopBullet(boss));
        } else if (!boss.atLocation3 && counter > 500){
            boss.ChangeState(new BossStateThree());
            boss.StartCoroutine(Wait(boss));
        }
    }

    IEnumerator Wait(Boss boss) {
        yield return new WaitForSeconds(6f);
        boss.MoveToLocation2();
    }
}
