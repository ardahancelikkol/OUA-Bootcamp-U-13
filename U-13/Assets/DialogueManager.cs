using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public GameObject DialoguePanel;
    public TextMeshProUGUI DialogueTMP;



    // Start is called before the first frame update
    void Start()
    {


        DialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialogue(string text)
    {
        string name = text.Split(':')[0];
        string dial = text.Split(':')[1].Trim();

        if(name == "King Lohan")
        {
            DialoguePanel.GetComponent<Image>().color = Color.cyan;
            DialogueTMP.color = Color.white;
        }
        else
        {
            DialoguePanel.GetComponent<Image>().color = Color.black;
            DialogueTMP.color = Color.white;
        }

        DialoguePanel.SetActive(true);
        DialogueTMP.text = dial;

    }

    public void EndDialogue()
    {
        DialoguePanel.SetActive(false);

    }
}
