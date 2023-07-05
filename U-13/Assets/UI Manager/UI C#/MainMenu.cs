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
        SceneManager.LoadScene("Abouth"); // Hakkýnda sahnesine geçiþ yapmak için sahne adý yaz
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings"); // Ayarlar sahnesine geçiþ yapmak için sahne adý yaz
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Buðra"); // Anamenü sahnesine geçiþ yapmak için sahne adý yaz
    }
}