using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPbar : MonoBehaviour {

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetValue(float health) {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void ResetBar() {
        slider.value = 1000;
        slider.maxValue = 1000;
        gradient.Evaluate(1f);
    }
}
