using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class King : MonoBehaviour {

    public DialogueManager dialogueManager;
    public TextMeshProUGUI dialogueTMP;
    public LayerMask playerLayer;
    public GameObject dialogueBox;


    [TextArea(3,10)] public string[] diags1;

    private int diagCount = 0;
    private string[] currentDiags;
    private Transform kingTransform;
    private bool dialogueActive;


    // Start is called before the first frame update
    void Start()
    {
        kingTransform = GetComponent<Transform>();

        currentDiags = diags1;
    }

    // Update is called once per frame
    void Update()
    {

        dialogueBox.SetActive(IsPlayerNear() && dialogueActive == false);


        if (IsPlayerNear() == false)
        {
            dialogueManager.EndDialogue();
        }

        if (Input.GetKeyDown(KeyCode.E) && IsPlayerNear())
        {
            if (diagCount == currentDiags.Length)
            {
                dialogueActive = false;
                dialogueManager.EndDialogue();
                diagCount = 0;
            }
            else
            {
                dialogueManager.ShowDialogue(currentDiags[diagCount]);
                dialogueActive = true;
                diagCount++;
            }
        }

    }

    private bool IsPlayerNear()
    {
        
        return Physics2D.Raycast(transform.position, Vector2.left, 2f, playerLayer);
    }
}
