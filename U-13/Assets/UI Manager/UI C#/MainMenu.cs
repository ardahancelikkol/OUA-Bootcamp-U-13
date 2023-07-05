using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void GoToAbouth()
    {
        SceneManager.LoadScene("Abouth"); // Hakk�nda sahnesine ge�i� yapmak i�in sahne ad� yaz
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings"); // Ayarlar sahnesine ge�i� yapmak i�in sahne ad� yaz
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Bu�ra"); // Anamen� sahnesine ge�i� yapmak i�in sahne ad� yaz
    }
}