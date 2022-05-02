using UnityEngine;

public class Music : MonoBehaviour {
    private static GameObject _instance;

    void Awake() {
        if (!_instance) {
            _instance = transform.gameObject;
        } else {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
    }
}
