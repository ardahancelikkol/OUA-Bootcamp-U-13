using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite_renderer;

    public Transform attackPos;
    public TextMeshProUGUI statsText;
    public TextMeshProUGUI Notes;
    public LayerMask enemyLayer;

    public float hspeed;
    public float maxspeed = 10;
    public float jumpForce;
    public float Health;
    public float Stress;
    public float Anxiety;
    public float attackRange;
    public float attackInterval = 0.3f;
    public int attackLandCount = 7;
    public float pDamage;
    public float red_duration;
    public float minAttackChance;
    public float maxAttackChance;
    public float maxStress;
    public float stress_duration;

    private Collider2D[] enemiesToDamage;
    private int attackLandTimer = -1;
    private float stress_timer;
    private float attackTimer;
    private bool isJump;
    private bool canHitEnemy;
    private float hmove;
    private string stats;
    private float red_timer = 0;
    private float attackChance;

    System.Random rnd = new System.Random();

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();


    }

    void Update()
    {
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);

        canHitEnemy = enemiesToDamage.Length > 0;

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


            animator.SetBool("isWalk", hmove != 0);

        if (Input.GetKeyDown(KeyCode.X) && (attackTimer <= 0))
        {
            attackTimer = attackInterval;
            attackLandTimer = attackLandCount;
            animator.SetTrigger("playAttack");
        }

        if (attackLandTimer == 0)
        {

            if (rnd.Next(0, 100) < attackChance)
            {
                Attack();
                StopAllCoroutines();
                StartCoroutine(showNote("Landed"));
            }
            else if (canHitEnemy)
            {
                TakeStress();
                StopAllCoroutines();
                StartCoroutine(showNote("Miss!"));

            }
        }



        animator.SetBool("isJumping", isJump);

        attackTimer -= Time.deltaTime;
        red_timer -= Time.deltaTime;
        attackLandTimer -= 1;

        if (red_timer > 0)
        {
            sprite_renderer.color = Color.red;
        }
        else
        {
            sprite_renderer.color = Color.white;
        }

        if (Stress > maxStress)
        {
            Stress = maxStress;
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
        if (red_timer <= 0)
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

    public void Attack()
    {

        foreach (Collider2D enemy in enemiesToDamage)
        {
            enemy.GetComponent<enemy>().TakeDamage(pDamage * (Stress * 0.12f));
        }
    }

    public IEnumerator showNote(string text)
    {
        Notes.text = text;
        yield return new WaitForSeconds(1f);
        Notes.text = " ";

    }
}
