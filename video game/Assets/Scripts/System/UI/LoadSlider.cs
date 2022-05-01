using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSlider : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider seSlider;
    // Start is called before the first frame update
    void Start()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("BGM");
        seSlider.value = PlayerPrefs.GetFloat("SE");
    }
}
