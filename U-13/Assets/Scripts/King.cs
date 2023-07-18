using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class King : MonoBehaviour {

    public DialogueManager dialogueManager;
    public TextMeshProUGUI dialogueTMP;
    public LayerMask playerLayer;
    public GameObject dialogueBox;


    [TextArea(3,10)] public string[] diags1;
    [TextArea(3,10)] public string[] diags2;
    [TextArea(3,10)] public string[] diags3;

    private int diagCount = 0;
    private string[] currentDiags;
    private Transform kingTransform;
    private bool dialogueActive;



    // Start is called before the first frame update
    void Start()
    {
        kingTransform = GetComponent<Transform>();

        if (PlayerPrefs.GetInt("gotgem") == 0 && PlayerPrefs.GetInt("killedBoss") == 0)
        {
            currentDiags = diags1;
        }
        else if(PlayerPrefs.GetInt("gotgem") == 1 && PlayerPrefs.GetInt("killedBoss") == 0)
        { currentDiags = diags2; }
        else
        { currentDiags = diags3; }
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
                if (currentDiags == diags3)
                {
                    StartCoroutine("EndTheGame");
                }
                else
                {
                    diagCount = 0;
                }
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

    private IEnumerator EndTheGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main Menu");

    }
}
