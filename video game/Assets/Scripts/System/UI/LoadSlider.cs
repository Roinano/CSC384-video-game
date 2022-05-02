using UnityEngine;
using UnityEngine.UI;

public class LoadSlider : MonoBehaviour {
    public Slider bgmSlider;
    public Slider seSlider;

    void Start() {
        bgmSlider.value = PlayerPrefs.GetFloat("BGM");
        seSlider.value = PlayerPrefs.GetFloat("SE");
    }
}
