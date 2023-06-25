using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button PlayButton;
    public Button SaveButton;

    private void Start()
    {
        // Butonlarýn týklama olaylarýný dinleyin
        PlayButton.onClick.AddListener(OnPlayButtonClicked);
        SaveButton.onClick.AddListener(OnSaveButtonClicked);
    }

    private void OnDestroy()
    {
        // Butonlarýn týklama olaylarýnýn dinlemesini kaldýrýn
        PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
        SaveButton.onClick.RemoveListener(OnSaveButtonClicked);
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