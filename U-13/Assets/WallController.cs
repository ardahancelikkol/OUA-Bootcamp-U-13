using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject ArenaWalls;
    public Transform BossSeeLoc;
    public Transform ArenaEntrance;
    public Transform PlayerTF;
    public BossController Boss;

    private bool arena_walls = false;
    private bool boss_saw = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (arena_walls == false && PlayerTF.position.x > ArenaEntrance.position.x)
        {
            arena_walls = true;
            ArenaWalls.SetActive(true);
        }

        if(boss_saw == false && PlayerTF.position.x > BossSeeLoc.position.x)
        {
            boss_saw = true;
            Boss.sawPlayer = true;

        }
    }
}
