using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject Prompt;
    public LayerMask playerLayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Prompt.SetActive(IsPlayerNear());

        if(IsPlayerNear() && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Next level!");
        }
    }

    private bool IsPlayerNear()
    {
        return Physics2D.Raycast(transform.position, Vector2.left, 4f, playerLayer); ;
    }
}
