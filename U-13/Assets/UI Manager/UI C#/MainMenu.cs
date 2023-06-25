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
        // Oyun baþlatma iþlemleri burada tanýmlanýr
        Debug.Log("Play");
        // Oyun sahnesini yükle veya gerekli iþlemleri yap
    }

    public void OnSettingsButtonClicked()
    {
        // Ayarlar menüsünü açma iþlemleri burada tanýmlanýr
        Debug.Log("Settings");
        // Ayarlar menüsünü aç veya gerekli iþlemleri yap
    }

    public void OnQuitButtonClicked()
    {
        // Uygulamadan çýkma iþlemleri burada tanýmlanýr
        Debug.Log("Quit");
        // Uygulamayý kapat veya gerekli iþlemleri yap
    }
}