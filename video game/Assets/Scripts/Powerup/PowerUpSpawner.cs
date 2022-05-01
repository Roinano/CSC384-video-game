using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    private float highInterval = 15f;
    private float lowInterval = 8f;

    void Start() {
        StartCoroutine(SpawnItem(Random.Range(lowInterval, highInterval)));
    }

    IEnumerator SpawnItem(float interval) {
        yield return new WaitForSeconds(interval);
        float rand = Random.Range(0, 3);
        GameObject item = null;
        switch(rand) {
            case 0:
                item = item1;
                break;
            case 1:
                item = item2;
                break;
            case 2:
                item = item3;
                break;
        }
        Instantiate(item, new Vector3(Random.Range(-12f, 13f), transform.position.y, transform.position.z), transform.rotation);
        StartCoroutine(SpawnItem(Random.Range(lowInterval, highInterval)));
    }
}
