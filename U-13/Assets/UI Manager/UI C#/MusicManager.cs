using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuMusic; // Oyun menüsünde çalýnacak müzik
    public AudioClip gameMusic; // Oyun alanýnda çalýnacak müzik

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMenuMusic(); // Oyun baþladýðýnda menü müziði çalýnacak þekilde ayarlayýn
    }

    public void PlayMenuMusic()
    {
        audioSource.Stop(); // Önceki müziði durdurun (varsa)
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameMusic()
    {
        audioSource.Stop(); // Önceki müziði durdurun (varsa)
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
        musicManager.PlayMenuMusic(); // Oyun UI ekraný açýldýðýnda menü müziði çalýnacak þekilde ayarlayýn
    }

    private void OnDisable()
    {
        musicManager.StopMusic(); // Oyun baþladýðýnda müziði durdurun
    }

    // Diðer kodlar...
}

/*using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuMusic; // Oyun menüsünde çalýnacak müzik
    public AudioClip gameMusic; // Oyun alanýnda çalýnacak müzik

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuMusic()
    {
        audioSource.Stop(); // Önceki müziði durdurun (varsa)
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameMusic()
    {
        audioSource.Stop(); // Önceki müziði durdurun (varsa)
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
        musicManager.PlayMenuMusic(); // Oyun UI ekraný açýldýðýnda menü müziði çalýnacak þekilde ayarlayýn
    }

    private void OnDisable()
    {
        musicManager.StopMusic(); // Oyun baþladýðýnda müziði durdurun
    }

    // Diðer kodlar...
}*/