using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void GoToArdahanScene()
    {
        // Ardahan adl� sahneye y�nlendirme yap
        SceneManager.LoadScene("Ardahan");
    }
}