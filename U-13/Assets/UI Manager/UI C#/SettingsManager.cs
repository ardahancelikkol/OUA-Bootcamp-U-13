using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;

    private void Start()
    {
        // Kaydedilmi� ses d�zeyini y�kleyin ve slider'� g�ncelleyin
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);

        // Kaydedilmi� tam ekran modunu y�kleyin ve toggle'� g�ncelleyin
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetVolume(float volume)
    {
        // Slider de�eri de�i�ti�inde �a�r�l�r ve ses d�zeyini g�nceller
        AudioListener.volume = volume;

        // Ses d�zeyini kaydedin
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        // Toggle durumu de�i�ti�inde �a�r�l�r ve tam ekran modunu g�nceller
        Screen.fullScreen = isFullscreen;
    }
}