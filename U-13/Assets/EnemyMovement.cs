using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform PlayerTF;
    public PlayerController player;
    
    public float hspeed = 20;
    public float maxspeed = 10;
    public float seeRange = 10;
    public float attackRange = 0.7f;
    public float attackInterval = 2f;
    public float damage = 5;

    private float attackTimer = 0;
    private float distance;
    private float side;
    private Rigidbody2D rb2d;
    private Animator animator;
    private bool canAttack;

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
        canAttack = attackTimer < 0;
        animator.SetBool("canAttack", canAttack);

        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * side, transform.localScale.y, transform.localScale.z);

        if (Mathf.Abs(distance) < seeRange && Mathf.Abs(distance) > attackRange)
        {
            EnemyMove(side);
        }
        else if(Mathf.Abs(distance) < attackRange && canAttack)
        {
            EnemyAttack();
        }
        else
        {
            animator.SetBool("canWalk", false);
        }

        attackTimer -= Time.deltaTime;
    }

    private void EnemyMove(float direction)
    {
        transform.position = new Vector2(transform.position.x - (hspeed * direction / 1000), transform.position.y);
        animator.SetBool("canWalk", true);
    }

    private void EnemyAttack()
    {
        attackTimer = attackInterval;
        animator.SetTrigger("Attack");
    }

    public void DamagePlayer()
    {
        player.TakeDamage(damage);
    } 
}
