using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateOne : BossState
{
    private int counter = 0;
    public BossState DoState(Boss bossState) {
        bossState.StartCoroutine(LoopBullet(bossState));
        LoopBullet(bossState);
        return null;
    }

    IEnumerator LoopBullet(Boss boss) {
        yield return new WaitForSeconds(0.85f);
        boss.BulletSpread();
        counter++;
        if (counter < 30) {
            boss.StartCoroutine(LoopBullet(boss));
        } else {
            boss.ChangeState(new BossStateTwo());
            boss.StartCoroutine(Wait(boss));
        }
            
        
    }

    IEnumerator Wait(Boss boss) {
        yield return new WaitForSeconds(3f);
        boss.MoveLocation3to4();
    }
}
