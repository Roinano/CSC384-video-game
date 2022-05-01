using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateThree : BossState {
    private int counter;
    private float rand;
    public BossState DoState(Boss bossState) {
        bossState.EnableLaser();
        counter = 0;
        bossState.StartCoroutine(WaitFor1Sec(bossState));
        return null;
    }

    IEnumerator Rotate(Boss boss) {
        yield return new WaitForSeconds(0.001f);
        
        if (counter%1000 == 0) {
            rand = Random.Range(-1, 1);
        }

        if (rand >= 0) {
            boss.ShootLaser(1f);
        } else {
            boss.ShootLaser(-1f);
        }
        counter++;

        if (counter%30 == 0) {
            boss.BulletRandom();
        }

        if (counter < 7500) {
            boss.StartCoroutine(Rotate(boss));
        } else {
            boss.ChangeState(new BossStateOne());
            boss.DisableLaser();
            boss.StartCoroutine(Wait(boss));
        }
    }

    IEnumerator Wait(Boss boss) {
        yield return new WaitForSeconds(3f);
        boss.MoveToLocation1();
    }

    IEnumerator WaitFor1Sec(Boss boss) {
        yield return new WaitForSeconds(2f);
        boss.StartCoroutine(Rotate(boss));
    }
}
