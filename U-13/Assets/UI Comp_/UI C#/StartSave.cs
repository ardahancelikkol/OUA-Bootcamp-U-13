using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button playButton;
    public Button saveButton;

    private void Start()
    {
        // Butonlarýn týklama olaylarýný dinleyin
        playButton.onClick.AddListener(OnPlayButtonClicked);
        saveButton.onClick.AddListener(OnSaveButtonClicked);
    }

    private void OnDestroy()
    {
        // Butonlarýn týklama olaylarýnýn dinlemesini kaldýrýn
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        saveButton.onClick.RemoveListener(OnSaveButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        // Oyunu baþlatma iþlemleri burada tanýmlanýr
        Debug.Log("Start");
    }

    private void OnSaveButtonClicked()
    {
        // Oyunu kaydetme iþlemleri burada tanýmlanýr
        Debug.Log("Save");
    }
}