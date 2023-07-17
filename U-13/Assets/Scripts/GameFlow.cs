using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{

    public GameObject PlayerPrefab;
    public GameObject KingPrefab;
    public Transform KingPos;
    public Transform Entrance;
    public Transform Exit;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(PlayerPrefab, Entrance);
        Instantiate(KingPrefab, KingPos);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
