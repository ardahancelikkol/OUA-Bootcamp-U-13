using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public HitBox hitBox;
    public Transform PlayerTF;
    public PlayerController player;
    
    public float hspeed = 20;
    public float maxspeed = 10;
    public float seeRange = 10;
    public float attackRange = 0.7f;
    public float attackInterval = 2f;
    public float damage = 5;
    public float red_duration = 0.3f;
    public float Health;


    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer sr;

    private float attackTimer = 0;
    private float distance;
    private float side;
    private bool canAttack;
    private float red_counter;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
        else if(Mathf.Abs(distance) < attackRange && canAttack && player.Alive)
        {
            EnemyAttack();
        }
        else
        {
            animator.SetBool("canWalk", false);
        }

        attackTimer -= Time.deltaTime;
        red_counter -= Time.deltaTime;

        if(red_counter > 0)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.white;
        }
    }

    private void EnemyMove(float direction)
    {
        transform.position = new Vector2(transform.position.x - (hspeed * direction / 100), transform.position.y);
        animator.SetBool("canWalk", true);
    }

    private void EnemyAttack()
    {
        attackTimer = attackInterval;
        animator.SetTrigger("Attack");
    }

    public void DamagePlayer()
    {
        if (hitBox.HitPlayer)
        {
            player.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        if (red_counter < 0)
        {
            Health -= damage;
            red_counter = red_duration;
        }

    }
}
