using UnityEngine;

public class Scroller : MonoBehaviour {
    public GameObject cam;
    public float scrollingSpeed;

    private void FixedUpdate() {
        transform.position = new Vector3(transform.position.x, transform.position.y + scrollingSpeed, transform.position.z);
        if (transform.position.y < cam.transform.position.y - 30) {
            transform.position = new Vector3(transform.position.x, cam.transform.position.y + 10, transform.position.z);
        }
    }
}
