using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void GoToArdahanScene()
    {
        // Ardahan adlý sahneye yönlendirme yap
        SceneManager.LoadScene("Ardahan");
    }
}