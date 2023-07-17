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
        SceneManager.LoadScene("Abouth"); // Hakk�nda sahnesine ge�i� yapar
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings"); // Ayarlar sahnesine ge�i� yapar
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Bu�ra"); // Anamen� sahnesine ge�i� yapar
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Ardahan"); // Restart butonu t�kland���nda "Ardahan" sayfas�na y�nlendirme yapar
    }
}