using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public PlayerController player;
    public GameObject HPpanel;
    public Transform PlayerTF;
    public RectTransform HPbar;
    public HitBox hitbox;

    public float Health;
    public float MaxHealth = 300;
    public bool sawPlayer = false;
    public float attackDistance;
    public float Hspeed = 3;
    public float Damage;
    public float attackInterval = 2f;

    private bool Alive = true;
    private bool canAttack;
    private float distance;
    private float side;
    private float attackTimer = 0f;

    private Animator animator;
    
    void Start()
    {
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
        }

        attackTimer -= Time.deltaTime;

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
        if (hitbox.HitPlayer)
        {
            player.TakeDamage(Damage);
        }
    }
}
