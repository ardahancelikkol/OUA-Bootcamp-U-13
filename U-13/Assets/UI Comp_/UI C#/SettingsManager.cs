using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public Dropdown qualityDropdown;

    private void Start()
    {
        // Baþlangýçta kaydedilmiþ ayarlarý yükle
        LoadSettings();

        // UI bileþenlerine kaydetme olaylarýný ekleyin
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenChanged);
        qualityDropdown.onValueChanged.AddListener(OnQualityChanged);
    }

    private void OnDestroy()
    {
        // UI bileþenlerine kaydetme olaylarýný kaldýrýn
        volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
        fullscreenToggle.onValueChanged.RemoveListener(OnFullscreenChanged);
        qualityDropdown.onValueChanged.RemoveListener(OnQualityChanged);
    }

    private void LoadSettings()
    {
        // Kaydedilmiþ ayarlarý yükle ve UI bileþenlerine uygula
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        int savedQuality = PlayerPrefs.GetInt("Quality", 2);

        volumeSlider.value = savedVolume;
        fullscreenToggle.isOn = savedFullscreen;
        qualityDropdown.value = savedQuality;
    }

    private void SaveSettings()
    {
        // Ayarlarý kaydet
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Quality", qualityDropdown.value);
        PlayerPrefs.Save();
    }

    private void OnVolumeChanged(float volume)
    {
        // Ses düzeyi deðiþtiðinde çaðrýlýr
        // Ses ayarlarýný güncelleyin
        Debug.Log("Volume changed: " + volume);
        SaveSettings();
    }

    private void OnFullscreenChanged(bool fullscreen)
    {
        // Tam ekran ayarý deðiþtiðinde çaðrýlýr
        // Tam ekran ayarlarýný güncelleyin
        Debug.Log("Fullscreen changed: " + fullscreen);
        SaveSettings();
    }

    private void OnQualityChanged(int qualityIndex)
    {
        // Kalite seçimi deðiþtiðinde çaðrýlýr
        // Kalite ayarlarýný güncelleyin
        Debug.Log("Quality changed: " + qualityIndex);
        SaveSettings();
    }
}