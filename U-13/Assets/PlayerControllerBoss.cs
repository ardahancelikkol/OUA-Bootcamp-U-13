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
    public int attackLandCount = 7;
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
    private int attackLandTimer = -1;
    private float stress_timer;
    private float attackTimer;
    private bool isJump;
    private bool canHitEnemy;
    private float hmove;
    private float red_timer = 0;
    private float attackChance;
    private bool PanicMode = false;
    private bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
