using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public PlayerController player;
    public GameObject HPpanel;
    public Transform PlayerTF;
    public Transform AttackPos;
    public RectTransform HPbar;
    public LayerMask playerLayer;

    public float Health;
    public float MaxHealth = 300;
    public bool sawPlayer = false;
    public float attackDistance;
    public float Hspeed = 3;
    public float Damage;
    public float attackInterval = 2f;
    public float attackRange;
    public float red_duration;

    private bool Alive = true;
    private bool canAttack;
    private float distance;
    private float side;
    private float attackTimer = 0f;
    private float red_counter = 0f;

    private Animator animator;
    private SpriteRenderer sr;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        distance = transform.position.x - PlayerTF.position.x;
        canAttack = Mathf.Abs(distance) <= Mathf.Abs(attackDistance);
        side = Mathf.Sign(distance);
        
        HPbar.localScale = new Vector2(Health / MaxHealth, 1);
        HPpanel.SetActive(sawPlayer);

        if (side != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * side, transform.localScale.y, transform.localScale.z);
        }

        if (sawPlayer && Alive && canAttack && attackTimer < 0f)
        {
            Attack();

        }else if(sawPlayer && Alive && !canAttack)
        {
            FollowThePlayer();
            animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsRun", false);

        }

        attackTimer -= Time.deltaTime;
        red_counter -= Time.deltaTime;

        if(red_counter > 0)
        { sr.color = Color.red; }
        else
        {
            sr.color = Color.white;
        }

    }

    private void FollowThePlayer()
    {
        transform.position = new Vector3(transform.position.x - Hspeed / 100 * side, transform.position.y, transform.position.z);
    }

    private void Attack()
    {
        attackTimer = attackInterval;
        animator.SetTrigger("Attack");
    }

    public void DamageThePlayer()
    {
        //if(Vector2.Distance(AttackPos.position, PlayerTF.position) < attackRange)
        //{
            player.TakeDamage(Damage);
        //}
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Outside red counter!");
        if(red_counter < 0)
        {
            Debug.Log("Inside red counter!");
            Health -= damage;
            red_counter = red_duration;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPos.position, attackRange);
    }
}
