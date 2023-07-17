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
        SceneManager.LoadScene("Abouth"); // Hakkýnda sahnesine geçiþ yapar
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings"); // Ayarlar sahnesine geçiþ yapar
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Buðra"); // Anamenü sahnesine geçiþ yapar
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Ardahan"); // Restart butonu týklandýðýnda "Ardahan" sayfasýna yönlendirme yapar
    }
}