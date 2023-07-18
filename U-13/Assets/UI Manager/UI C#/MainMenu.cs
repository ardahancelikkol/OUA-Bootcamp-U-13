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
    public void GoToAbout()
    {
        SceneManager.LoadScene("About"); // Hakkýnda sahnesine geçiþ yapar
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings"); // Ayarlar sahnesine geçiþ yapar
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Anamenü sahnesine geçiþ yapar
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Castle"); // Restart butonu týklandýðýnda "Ardahan" sayfasýna yönlendirme yapar
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("gotgem", 0);
        PlayerPrefs.SetInt("killedBoss", 0);
        PlayerPrefs.SetFloat("Health", 100f);
        PlayerPrefs.SetFloat("Stress", 0f);


    }
}