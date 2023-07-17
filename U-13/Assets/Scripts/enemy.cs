using UnityEngine;
using TMPro;

public class enemy : MonoBehaviour
{

    public Transform attackPos;
    public LayerMask playerLayer;
    public RectTransform healthBar;
    public TextMeshProUGUI deathCountText;


    public float Health;
    public float MaxHealth = 100;
    public float loopDuration;
    public float attackRange;
    public float damage;
    public int deathCount = 0;

    private SpriteRenderer enemy_sprite;
    private Animator animator;
    private float loopCounter;
    private string stats;
    private float red_counter;
    private float red_duration = 0.3f;

    void Start()
    {
        loopCounter = loopDuration;

        enemy_sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        loopCounter -= Time.deltaTime;
        deathCountText.text = "Death Count: " + deathCount.ToString();


        healthBar.localScale = new Vector3(Health / MaxHealth, healthBar.localScale.y, healthBar.localScale.z);

        if (red_counter < 0f)
        {
            enemy_sprite.color = Color.white;
        }
        else
        {
            enemy_sprite.color = Color.red;
        }

        red_counter -= Time.deltaTime;

        if(loopCounter <= 0)
        {
            Attack();
            loopCounter = loopDuration;

        }

        if(enemy_sprite.sprite.name == "Attacks_3")
        {
            Collider2D[] players = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerLayer);

            foreach (Collider2D player in players)
            {
                player.GetComponent<PlayerController>().TakeDamage(damage);
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void Attack()
    {
        animator.SetTrigger("enemyAttack");

    }

    public void TakeDamage(float damage)
    {
        if (red_counter < 0)
        {
            Health -= damage;
            red_counter = red_duration;

            if(Health <= 0)
            {
                Health = MaxHealth;
                deathCount++;
                    
                    }
        }

    }

}
