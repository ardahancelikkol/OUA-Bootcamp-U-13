using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public PlayerController player;
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
            PlayerPrefs.SetFloat("Health", player.Health);
            PlayerPrefs.SetFloat("Stress", player.Stress);
            if (PlayerPrefs.GetInt("gotgem") == 0)
            {
                SceneManager.LoadScene("Village");
            }
            else
            {
                SceneManager.LoadScene("Church");
            }
        }
    }

    private bool IsPlayerNear()
    {
        return Physics2D.Raycast(transform.position, Vector2.left, 4f, playerLayer); ;
    }
}
