using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBoss : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask groundLayer;
    public LayerMask bossLayer;
    public RectTransform healthBar;
    public RectTransform stressBar;

    private CapsuleCollider2D collider2d;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite_renderer;

    public float hspeed;
    public float maxspeed = 10;
    public float jumpForce;
    public float MaxHealth = 100;
    
    [Range(0, 100)]
    public float Health;
    
    [Range(0,100)]
    public float Stress;
    
    public float Anxiety = 3;
    public float attackRange = 5;
    public float attackInterval = 0.3f;
    public float pDamage = 5;
    public float red_duration = 0.5f;
    public float minAttackChance = 10;
    public float maxAttackChance = 90;
    public float maxStress = 100;
    public float stress_duration;
    public float PanicDamage = 0.006f;
    public int deathCount = 0;
    public bool Alive = true;

    private Collider2D[] bossesToDamage;
    private float stress_timer;
    private float attackTimer;
    private bool isJump;
    private bool canHitEnemy;
    private float hmove;
    private float red_timer = 0;
    private float attackChance;
    private bool PanicMode = false;
    private bool Grounded;

    System.Random rnd = new System.Random();

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        Stress = PlayerPrefs.GetFloat("Stress");

        collider2d = GetComponent<CapsuleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        bossesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, bossLayer);
        canHitEnemy = bossesToDamage.Length > 0;

        hmove = Input.GetAxisRaw("Horizontal");
        isJump = Input.GetKeyDown(KeyCode.Space);
        Grounded = IsGrounded();


        animator.SetBool("isWalk", hmove != 0);
        animator.SetBool("isJumping", isJump);
        animator.SetBool("isPanic", PanicMode);
        animator.SetBool("isGrounded", Grounded);

        if (hmove != 0) { transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * hmove, transform.localScale.y, 0); }
        if (isJump && Grounded && Alive) { rb.velocity = Vector2.up * jumpForce; }

        if (PanicMode)
        {
            attackChance = 100f;
        }
        else
        {
            attackChance = maxAttackChance - (Stress * ((maxAttackChance - minAttackChance) / maxStress));
        }

        if (Input.GetMouseButtonDown(0) && (attackTimer <= 0) && Alive)
        {
            Attack();
        }

        if (red_timer > 0)
        {
            sprite_renderer.color = Color.black;
        }
        else
        {
            sprite_renderer.color = Color.white;
        }

        if (Stress >= maxStress && PanicMode == false)
        {
            PanicMode = true;
            Health /= 2;

        }

        if (PanicMode)
        {
            Health -= PanicDamage;
            PanicDamage = 1.003f * PanicDamage;
            sprite_renderer.color = Color.red;

            if (Stress <= 0)
            {
                PanicMode = false;
                PanicDamage = 0.006f;
                sprite_renderer.color = Color.white;
            }
        }


        /////////////////////////////////

        attackTimer -= Time.deltaTime;
        red_timer -= Time.deltaTime;


        if (Stress >= maxStress) { Stress = maxStress; }
        if (Stress <= 0) { Stress = 0; }
        if (Health >= MaxHealth) { Health = MaxHealth; }
        if (Health <= 0) { Health = 0; }

        if (Health <= 0 && Alive)
        {
            Die();
        }



    }

    private void LateUpdate()
    {

        healthBar.localScale = new Vector3(Health / MaxHealth, healthBar.localScale.y, healthBar.localScale.z);
        stressBar.localScale = new Vector3(Stress / maxStress, healthBar.localScale.y, healthBar.localScale.z);
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

    private bool IsGrounded()
    {
        return Physics2D.Raycast(collider2d.bounds.center, Vector2.down, collider2d.bounds.extents.y + 1f, groundLayer);
    }
    
    public void TakeDamage(float damage)
    {
        if (red_timer <= 0)
        {
            red_timer = red_duration;
            Health -= damage * (1 + 0.2f * Stress);
            Stress += Anxiety * (1 + (damage * 0.2f));
        }

    }

    /////////////////////////////


    private void Attack()
    {
        attackTimer = attackInterval;
        animator.SetTrigger("playAttack");
    }

    private void HitAttack()
    {
        if(canHitEnemy)
        {
            if (rnd.Next(0, 100) <= attackChance)
            {
                LandAttack();
            }
            else
            {
                TakeStress();
            }
        }
    }

    private void LandAttack()
    {
        foreach(Collider2D boss in bossesToDamage)
        {
            boss.GetComponent<BossController>().TakeDamage(pDamage * (1 + Stress * 0.12f));
        }

    }

    private void TakeStress()
    {
        Stress += Anxiety;
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        hspeed = 0;
        jumpForce = 0;
        Alive = false;
    }
}
