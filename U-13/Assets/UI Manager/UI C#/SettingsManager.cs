using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;

    private void Start()
    {
        // Kaydedilmiþ ses düzeyini yükleyin ve slider'ý güncelleyin
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);

        // Kaydedilmiþ tam ekran modunu yükleyin ve toggle'ý güncelleyin
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetVolume(float volume)
    {
        // Slider deðeri deðiþtiðinde çaðrýlýr ve ses düzeyini günceller
        AudioListener.volume = volume;

        // Ses düzeyini kaydedin
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        // Toggle durumu deðiþtiðinde çaðrýlýr ve tam ekran modunu günceller
        Screen.fullScreen = isFullscreen;
    }
}