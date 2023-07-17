using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLenght;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion

    private void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (inRange) 
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLenght, raycastMask);
            RaycastDebugger();
        }
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }

    private void OnTriggerEnter2D(Collider2D wave)
    {
        if (wave.gameObject.tag == "Player")
        {
            target = wave.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance (transform.position, target.transform.position);
        
        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        
        if (cooling)
        {
            Cooldown();
            anim.SetBool ("Attack", false );
        }
    }

    private void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x , target.transform.position.y);
            transform.position = Vector2.MoveTowards (transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling &&attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    private void StopAttack()
    {
       cooling = false;
       attackMode = false;
       anim.SetBool("Attack", false);
    }

    private void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLenght, Color.red);
        }
        else if (distance < attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLenght, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}
