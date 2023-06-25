using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button PlayButton;
    public Button SaveButton;

    private void Start()
    {
        // Butonlar�n t�klama olaylar�n� dinleyin
        PlayButton.onClick.AddListener(OnPlayButtonClicked);
        SaveButton.onClick.AddListener(OnSaveButtonClicked);
    }

    private void OnDestroy()
    {
        // Butonlar�n t�klama olaylar�n�n dinlemesini kald�r�n
        PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
        SaveButton.onClick.RemoveListener(OnSaveButtonClicked);
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