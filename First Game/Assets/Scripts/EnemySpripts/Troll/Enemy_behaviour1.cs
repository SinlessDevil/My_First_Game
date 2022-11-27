using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour1 : MonoBehaviour
{
    #region Public Variables
 
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum distance
    public float moveSpeed;
    public int damage;
    public float timer; //Cooldown of attacks
    public Transform leftLimit;
    public Transform rightLimit;
    public GameObject deathEffect;
    [SerializeField] private AudioSource attackMob;
    [SerializeField] private AudioSource attackMiss;
    [SerializeField] private AudioSource enemifootstep;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    private Animator animator;
    private float distance; //store distance between enemy and player
    private bool attackMode;
    private bool inRange; //See if player in range
    private bool cooling; //check if enemy is cooling after attack
    private float intTimer;
    private Player player;
    private bool _isPlayerNear;
    #endregion 

    private  Enemy1 Enrgy;

    void Awake()
    {
        SelectTarget();
        player = FindObjectOfType<Player>();
        intTimer = timer;
        animator = GetComponent<Animator>();
        attackMiss = GetComponent<AudioSource>();
        enemifootstep = GetComponent<AudioSource>();
        Enrgy = GetComponent<Enemy1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enrgy.health < 15)
        {
            animator.SetTrigger("Engry");
            damage = 6;
            moveSpeed = 5;
            attackDistance = 5;
        }      

        if (!attackMode)
        {
            Move();
        }

        if(!InsideoLimits() && !inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyTroll_Attack"))
        {
            SelectTarget();
        }
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask);
            RaycastDebugger();
        }

        //When player is detected
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
        
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.transform.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            _isPlayerNear = true;
            Flip();
        }
    }

    void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.transform.tag == "Player")
        {
            _isPlayerNear = false; // отмечаем, что игрок НЕ рядом        
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            animator.SetBool("Attack", false);
        }
    }

    void Move()
    {
        animator.SetBool("canWalk", true);

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyTroll_Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        animator.SetBool("canWalk", false);
        animator.SetBool("Attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attack", false);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideoLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if(distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }
        Flip();
    }

   private void Flip()
   {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
   }

    public void OnEnemyAttack()
    {
        if (_isPlayerNear)
        {
            Shake.instance.StartShake(.2f, .1f);
            Instantiate(deathEffect, player.transform.position, Quaternion.identity);
            player.health -= damage;
            attackMob.Play();
        }
        attackMob.Play();
    }

    private void AttackMiss()
    {
        attackMiss.Play();
    }

    private void Enemifootstep()
    {
        enemifootstep.Play();
    }

}

