using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{


    public Transform attackPos;
    public TextMeshProUGUI Notes;
    public LayerMask enemyLayer;
    public RectTransform healthBar;
    public RectTransform stressBar;
    public TextMeshProUGUI deathCountText;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite_renderer;

    public float hspeed;
    public float maxspeed = 10;
    public float jumpForce;
    public float Health;
    public float MaxHealth = 100;

    [Range(0,100)]
    public float Stress;
    
    public float Anxiety;
    public float attackRange;
    public float attackInterval = 0.3f;
    public int attackLandCount = 7;
    public float pDamage;
    public float red_duration;
    public float minAttackChance = 10;
    public float maxAttackChance = 90;
    public float maxStress = 100;
    public float stress_duration;
    public int deathCount = 0;

    private Collider2D[] enemiesToDamage;
    private int attackLandTimer = -1;
    private float stress_timer;
    private float attackTimer;
    private bool isJump;
    private bool canHitEnemy;
    private float hmove;
    private float red_timer = 0;
    private float attackChance;
    private bool TriggerMode = false;
    private float TriggerDur;
    private float TriggerTimer = 0;

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
        deathCountText.text = "Death Count: " + deathCount.ToString();


        if (TriggerMode)
        {
            attackChance = 100f;
        }
        else
        {
            attackChance = maxAttackChance - (Stress * ((maxAttackChance - minAttackChance) / maxStress));
        }

        hmove = Input.GetAxisRaw("Horizontal");
        isJump = Input.GetKeyDown(KeyCode.Space);

        healthBar.localScale = new Vector3(Health / MaxHealth, healthBar.localScale.y, healthBar.localScale.z);
        stressBar.localScale = new Vector3(Stress / maxStress, healthBar.localScale.y, healthBar.localScale.z);
        animator.SetBool("isWalk", hmove != 0);
        animator.SetBool("isJumping", isJump);

        ///////////////////////////////////

        if (hmove != 0) {transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * hmove, transform.localScale.y, 0);}

        if (isJump) {rb.velocity = Vector2.up * jumpForce;}



        if (Input.GetKeyDown(KeyCode.X) && (attackTimer <= 0))
        {
            attackTimer = attackInterval;
            attackLandTimer = attackLandCount;
            animator.SetTrigger("playAttack");
        }//when the attack is started

        if ((attackLandTimer == 0) && canHitEnemy)
        {

            if (rnd.Next(0, 100) <= attackChance)
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
        } //when the attack hits (can land or miss)


        if (red_timer > 0)
        {
            sprite_renderer.color = Color.red;
        }
        else
        {
            sprite_renderer.color = Color.white;
        }

        ////////////////////////////////

        //TRIGGER MODE

        if (Stress >= maxStress && TriggerMode == false) {
            TriggerMode = true;
            TriggerTimer = TriggerDur;
            Health /= 2;
        }

        if (TriggerMode)
        {
            Health -= 0.006f;
            sprite_renderer.color = Color.green;
            TriggerTimer -= Time.deltaTime;

            if (Stress <= 0)
            {
                TriggerMode = false;
                sprite_renderer.color = Color.white;
            }
        }


        /////////////////////////////////

        attackTimer -= Time.deltaTime;
        red_timer -= Time.deltaTime;
        attackLandTimer -= 1;
        if(Stress >= maxStress) { Stress = maxStress; }
        if(Stress <= 0) { Stress = 0; }
        if(Health >= MaxHealth) { Health = MaxHealth;}
        if(Health <= 0) { Health = 0; }

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
            Health -= damage * (0.2f * Stress);
            Stress += Anxiety * (1 + (damage * 0.2f));

            if(Health <= 0)
            {
                Health = MaxHealth;
                deathCount++;
            }
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
        if (TriggerMode)
        {
            Health += pDamage;
            Stress -= Anxiety;
        }
    }//Allows the player to attack each enemy seperately
        public IEnumerator showNote(string text)
    {
        Notes.text = text;
        yield return new WaitForSeconds(1f);
        Notes.text = " ";

    }
}
