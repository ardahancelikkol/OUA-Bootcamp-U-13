using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallController : MonoBehaviour
{
    public GameObject ArenaWalls;
    public Transform BossSeeLoc;
    public Transform ArenaEntrance;
    public Transform PlayerTF;
    public BossController Boss;
    public PlayerBoss Player;
    public Transform NextLevel;

    private bool arena_walls = false;
    private bool boss_saw = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (arena_walls == false && PlayerTF.position.x > ArenaEntrance.position.x && PlayerPrefs.GetInt("killedBoss") == 0)
        {
            arena_walls = true;
            ArenaWalls.SetActive(true);
        }

        if(boss_saw == false && PlayerTF.position.x > BossSeeLoc.position.x)
        {
            boss_saw = true;
            Boss.sawPlayer = true;

        }

        if(PlayerPrefs.GetInt("killedBoss") == 1)
        {
            arena_walls = false;
            ArenaWalls.SetActive(false);
        }

        if(PlayerTF.position.x > NextLevel.position.x)
        {
            PlayerPrefs.SetFloat("Health", Player.Health);
            PlayerPrefs.SetFloat("Stress", Player.Stress);

            SceneManager.LoadScene("Castle");
        }
    }
}
