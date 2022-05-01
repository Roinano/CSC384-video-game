using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour {
    private float length, startPos;
    public GameObject cam;
    public float scrollingSpeed;

    void Start() {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void FixedUpdate() {
        transform.position = new Vector3(transform.position.x, transform.position.y + scrollingSpeed, transform.position.z);
        if (transform.position.y < cam.transform.position.y - 30) {
            transform.position = new Vector3(transform.position.x, cam.transform.position.y + 10, transform.position.z);
        }
    }
}
