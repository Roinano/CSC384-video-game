using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{

    protected float hspeed;
    protected float vspeed;
    protected string mode;
    protected int type;
    protected GameObject enemy;

    private void Start() {
        Initialize();
        if (type == 1) {
            enemy.GetComponent<EnemyTypeOne>().vspeed = vspeed;
            enemy.GetComponent<EnemyTypeOne>().hspeed = hspeed;
        } else if (type == 2) {
            enemy.GetComponent<EnemyTypeTwo>().vspeed = vspeed;
            enemy.GetComponent<EnemyTypeTwo>().hspeed = hspeed;
        }
        //KnowTheType();
        if (mode == "side") {
            StartCoroutine(SpawnEnemyHorizontal(Random.Range(3f, 4.5f)));
        } else if (mode == "up") {
            StartCoroutine(SpawnEnemyVertical(Random.Range(4f, 6f)));
        }
        
    }

    void Update() {
        if (Battle.enemyDestroyed >= 5 && Battle.boss) {
            
            Destroy(gameObject);
        }
        
    }

    IEnumerator SpawnEnemyHorizontal(float interval) {
        yield return new WaitForSeconds(interval);
        Instantiate(enemy, new Vector3(Random.Range(transform.position.x, transform.position.x+2), Random.Range(0, 5f), transform.position.z), transform.rotation);
        StartCoroutine(SpawnEnemyHorizontal(Random.Range(2.5f, 4f)));
    }

    IEnumerator SpawnEnemyVertical(float interval) {
        yield return new WaitForSeconds(interval);
        Instantiate(enemy, new Vector3(Random.Range(-12, 12), Random.Range(transform.position.y, transform.position.y + 2), transform.position.z), transform.rotation);
        StartCoroutine(SpawnEnemyVertical(Random.Range(4f, 6f)));
    }

    public abstract void Initialize();
    //public abstract void DestroySpawner();
}
