using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public Dropdown qualityDropdown;

    private void Start()
    {
        // Ba�lang��ta kaydedilmi� ayarlar� y�kle
        LoadSettings();

        // UI bile�enlerine kaydetme olaylar�n� ekleyin
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenChanged);
        qualityDropdown.onValueChanged.AddListener(OnQualityChanged);
    }

    private void OnDestroy()
    {
        // UI bile�enlerine kaydetme olaylar�n� kald�r�n
        volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
        fullscreenToggle.onValueChanged.RemoveListener(OnFullscreenChanged);
        qualityDropdown.onValueChanged.RemoveListener(OnQualityChanged);
    }

    private void LoadSettings()
    {
        // Kaydedilmi� ayarlar� y�kle ve UI bile�enlerine uygula
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        int savedQuality = PlayerPrefs.GetInt("Quality", 2);

        volumeSlider.value = savedVolume;
        fullscreenToggle.isOn = savedFullscreen;
        qualityDropdown.value = savedQuality;
    }

    private void SaveSettings()
    {
        // Ayarlar� kaydet
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Quality", qualityDropdown.value);
        PlayerPrefs.Save();
    }

    private void OnVolumeChanged(float volume)
    {
        // Ses d�zeyi de�i�ti�inde �a�r�l�r
        // Ses ayarlar�n� g�ncelleyin
        Debug.Log("Volume changed: " + volume);
        SaveSettings();
    }

    private void OnFullscreenChanged(bool fullscreen)
    {
        // Tam ekran ayar� de�i�ti�inde �a�r�l�r
        // Tam ekran ayarlar�n� g�ncelleyin
        Debug.Log("Fullscreen changed: " + fullscreen);
        SaveSettings();
    }

    private void OnQualityChanged(int qualityIndex)
    {
        // Kalite se�imi de�i�ti�inde �a�r�l�r
        // Kalite ayarlar�n� g�ncelleyin
        Debug.Log("Quality changed: " + qualityIndex);
        SaveSettings();
    }
}