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
        slider.value = 3000;
        slider.maxValue = 3000;
        gradient.Evaluate(1f);
    }
}
