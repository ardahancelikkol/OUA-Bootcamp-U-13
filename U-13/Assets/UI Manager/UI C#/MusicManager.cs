using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuMusic; // Oyun men�s�nde �al�nacak m�zik
    public AudioClip gameMusic; // Oyun alan�nda �al�nacak m�zik

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMenuMusic(); // Oyun ba�lad���nda men� m�zi�i �al�nacak �ekilde ayarlay�n
    }

    public void PlayMenuMusic()
    {
        audioSource.Stop(); // �nceki m�zi�i durdurun (varsa)
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameMusic()
    {
        audioSource.Stop(); // �nceki m�zi�i durdurun (varsa)
        audioSource.clip = gameMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}

public class GameManager : MonoBehaviour
{
    public MusicManager musicManager;

    private void OnEnable()
    {
        musicManager.PlayMenuMusic(); // Oyun UI ekran� a��ld���nda men� m�zi�i �al�nacak �ekilde ayarlay�n
    }

    private void OnDisable()
    {
        musicManager.StopMusic(); // Oyun ba�lad���nda m�zi�i durdurun
    }

    // Di�er kodlar...
}

/*using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuMusic; // Oyun men�s�nde �al�nacak m�zik
    public AudioClip gameMusic; // Oyun alan�nda �al�nacak m�zik

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuMusic()
    {
        audioSource.Stop(); // �nceki m�zi�i durdurun (varsa)
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameMusic()
    {
        audioSource.Stop(); // �nceki m�zi�i durdurun (varsa)
        audioSource.clip = gameMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}

public class GameManager : MonoBehaviour
{
    public MusicManager musicManager;

    private void OnEnable()
    {
        musicManager.PlayMenuMusic(); // Oyun UI ekran� a��ld���nda men� m�zi�i �al�nacak �ekilde ayarlay�n
    }

    private void OnDisable()
    {
        musicManager.StopMusic(); // Oyun ba�lad���nda m�zi�i durdurun
    }

    // Di�er kodlar...
}*/