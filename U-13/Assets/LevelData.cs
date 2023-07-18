using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public Gem gem;
    public int EnemiesLeft;

    private GameObject[] enemies;


    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        EnemiesLeft = enemies.Length;
    }
    private void Update()
    {
        if(EnemiesLeft == 0)
        {
            gem.gameObject.SetActive(true);
        }
    }
}

