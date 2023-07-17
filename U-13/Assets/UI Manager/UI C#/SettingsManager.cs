using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;

    private void Start()
    {
        
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);

       
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetVolume(float volume)
    {
        // Slider de�eri de�i�ti�inde �a�r�l�r ve ses d�zeyini g�nceller
        AudioListener.volume = volume;

        
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        
        Screen.fullScreen = isFullscreen;
    }
}