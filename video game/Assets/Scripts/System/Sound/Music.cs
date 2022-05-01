using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    private static GameObject _instance;
    private void Awake() {
        if (!_instance) {
            _instance = transform.gameObject;
        } else {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
    }
}
