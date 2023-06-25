using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button playButton;
    public Button saveButton;

    private void Start()
    {
        // Butonlar�n t�klama olaylar�n� dinleyin
        playButton.onClick.AddListener(OnPlayButtonClicked);
        saveButton.onClick.AddListener(OnSaveButtonClicked);
    }

    private void OnDestroy()
    {
        // Butonlar�n t�klama olaylar�n�n dinlemesini kald�r�n
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        saveButton.onClick.RemoveListener(OnSaveButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        // Oyunu ba�latma i�lemleri burada tan�mlan�r
        Debug.Log("Start");
    }

    private void OnSaveButtonClicked()
    {
        // Oyunu kaydetme i�lemleri burada tan�mlan�r
        Debug.Log("Save");
    }
}