using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;

    public void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    public void OnDestroy()
    {
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        quitButton.onClick.RemoveListener(OnQuitButtonClicked);
    }

    public void OnPlayButtonClicked()
    {
        // Oyun ba�latma i�lemleri burada tan�mlan�r
        Debug.Log("Play");
        // Oyun sahnesini y�kle veya gerekli i�lemleri yap
    }

    public void OnSettingsButtonClicked()
    {
        // Ayarlar men�s�n� a�ma i�lemleri burada tan�mlan�r
        Debug.Log("Settings");
        // Ayarlar men�s�n� a� veya gerekli i�lemleri yap
    }

    public void OnQuitButtonClicked()
    {
        // Uygulamadan ��kma i�lemleri burada tan�mlan�r
        Debug.Log("Quit");
        // Uygulamay� kapat veya gerekli i�lemleri yap
    }
}