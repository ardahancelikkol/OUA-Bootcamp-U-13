using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            PlayerPrefs.SetInt("gotgem", 1);
            Destroy(gameObject);
            Debug.Log("Got gem!");
        }
    }
}
