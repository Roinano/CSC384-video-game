using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{

    public Slider slider;

    public void Decay() {
        slider.value -= 0.02f;
    }

    public void ResetBar() {
        slider.value = 0;
        slider.maxValue = 50;
    }

    public void AddEnergy(int energy) {
        slider.value += energy;
    }
}
