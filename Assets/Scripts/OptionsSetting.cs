using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class OptionsSetting : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider brightnessSlider;
    [SerializeField] Light directionalLight;

    private void Start()
    {
        volumeSlider.value = GameManager.volumeGame;
        brightnessSlider.value = GameManager.globalBrightness;
        AudioListener.volume = volumeSlider.value;
        directionalLight.intensity = brightnessSlider.value;
    }
    public void SetVolumeLevel()
    {
        GameManager.volumeGame = volumeSlider.value;
        AudioListener.volume = volumeSlider.value;
    }

    public void SetBrightnessLevel()
    {
        GameManager.globalBrightness = brightnessSlider.value;
        directionalLight.intensity = brightnessSlider.value;
    }

    public void SetDifficultyLevel(int level)
    {
        GameManager.difficultyLevel = level;
    }

    
}
