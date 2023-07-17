using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform PlayerTF;
    public float hspeed = 20;
    public float maxspeed = 10;
    public float seeRange = 10;
    
    private float distance;
    private float side;
    private Rigidbody2D rb2d;
    private Animator animator;
    private float scaleside;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = transform.position.x - PlayerTF.position.x;
        side = Mathf.Sign(distance);

        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * side, transform.localScale.y, transform.localScale.z);

        if (Mathf.Abs(distance) < seeRange && rb2d.velocity.x < maxspeed)
        {
            EnemyMove(side);
        }
        else
        {
            animator.SetBool("canWalk", false);
        }
    }

    private void EnemyMove(float direction)
    {
        transform.position = new Vector2(transform.position.x - (hspeed * direction / 1000), transform.position.y);
        animator.SetBool("canWalk", true);
    }
}
