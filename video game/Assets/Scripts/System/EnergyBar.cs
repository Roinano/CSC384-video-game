using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {
    public Slider slider;
    private bool pause = false;

    public void Decay() {
        if (!pause) {
            slider.value -= 0.05f;
        }
    }

    public void ResetBar() {
        slider.value = 0;
        slider.maxValue = 50;
    }

    public void AddEnergy(int energy) {
        slider.value += energy;
    }

    public void StopBar() {
        pause = true;
    }
    
    public void ResumeBar() {
        pause = false;
    }
}
