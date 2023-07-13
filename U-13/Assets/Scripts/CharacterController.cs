using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Transform ptransform;
    private Animator animator;
    private SpriteRenderer sprite_renderer;

    public Transform attackPos;
    public TextMeshProUGUI statsText;
    public LayerMask enemyLayer;

    public float hspeed;
    public float maxspeed = 10;
    public float jumpForce;
    public float Health;
    public float Stress;
    public float Anxiety;
    public float attackDur;
    public float attackRange;
    public float attackInterval;
    public float pDamage;
    public float red_duration;
    public float minAttackChance;
    public float maxAttackChance;
    public float maxStress;
    public float stress_duration;

    private float stress_timer;
    private float attackTimer;
    private bool isJump;
    private float hmove;
    private string stats;
    private float red_timer = 0;
    private float attackChance;

    System.Random rnd = new System.Random();

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ptransform = gameObject.GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();


    }

    void Update()
    {
        hmove = Input.GetAxisRaw("Horizontal");
        isJump = Input.GetKeyDown(KeyCode.Space);

        stats = string.Format("Health: {0}\nStress: {1}", Health, Stress);
        statsText.text = stats;

        attackChance = maxAttackChance - Stress;

        if (hmove != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * hmove, transform.localScale.y, 0);
        }

        if (isJump)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (hmove != 0)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.X) && (attackDur - attackTimer >= attackInterval))
        {
            attackTimer = attackDur;
            animator.SetTrigger("playAttack");
        }

        if (sprite_renderer.sprite.name == "Attack1_2")
        {

            if (rnd.Next(0, 100) < attackChance)
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);



                foreach (Collider2D enemy in enemiesToDamage)
                {

                    enemy.GetComponent<enemy>().TakeDamage(pDamage);
                }
            }
            else
            {
                //TakeStress();
            }
        }
 



        attackTimer -= Time.deltaTime;


        animator.SetBool("isJumping", isJump);

        red_timer -= Time.deltaTime;
        stress_timer = -Time.deltaTime;

        if (red_timer > 0)
        {
            sprite_renderer.color = Color.red;
        }
        else
        {
            sprite_renderer.color = Color.white;
        }


    }

    void FixedUpdate()
    {
        charMove(hmove, hspeed);


        void charMove(float dir, float acc)
        {
            if (rb.velocity.x < maxspeed && rb.velocity.x > -maxspeed)
            {
                rb.AddForce(new Vector2(dir * acc, 0), ForceMode2D.Impulse);
            }

        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void TakeDamage(float damage)
    { 
        if(red_timer <= 0)
        {
            red_timer = red_duration;
            Health -= damage + (0.2f * Stress);
            Stress += Anxiety * (damage * 0.2f);
        }

    }

    public void TakeStress()
    {
        if (stress_timer < 0)
            stress_timer = stress_duration;
            Stress += Anxiety;
    }



    }
