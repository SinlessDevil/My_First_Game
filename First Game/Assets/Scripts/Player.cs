using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource death;

    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    public Vector2 moveVector;
    private bool facingRight = true;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int health;

    private int extraJumps;
    public int extraJumpsValue;
    private Animator anim;
    public GameObject deafetUI;

    private void Start()
    {
        anim = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        footstep = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
            
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
                
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            if (health < 1)
            {
                death.Play();
                deafetUI.SetActive(true);
                Time.timeScale = 0f;               
            }        
        }
   
     isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            flip();         
        }
        else if (facingRight == true && moveInput < 0)
        {
            flip();          
        }

   

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
            
        }
        else
        {
            anim.SetBool("isRunning", true);
           
        }
    }

    private void Update()
    {        

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }


        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            anim.SetTrigger("takeOf");
            jumpSound.Play();
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOf");
            jumpSound.Play();          
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        CheckingLadder();
        LadderMechanics();
        LadderUpDown();
    }

    void flip()
    {

        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = collision.transform;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
            
        }
    }

    public float check_RADIUS = 0.04f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(CHECK_Ladder.position, check_RADIUS);
    }

    public Transform CHECK_Ladder;
    public bool checkedLadder;
    public LayerMask LadderMask;

    void CheckingLadder()
    {
        checkedLadder = Physics2D.OverlapPoint(CHECK_Ladder.position, LadderMask);
        anim.SetBool("onLedder", checkedLadder);
    }

    public float ladderSpeed = 1.5f;

    void LadderMechanics()
    {
        if(checkedLadder) 
        { 
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2(rb.velocity.x, moveVector.y * ladderSpeed);
        }
        else { rb.bodyType = RigidbodyType2D.Dynamic; }
    }

    void LadderUpDown()
    {
        moveVector.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("moveY", moveVector.y);
    }

    private void Footstep()
    {
        footstep.Play();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealsClip>())
        {
            if(health > 10)
            {
                health += 0;              
            }
            else
            {
                health += 1;
            }  
            Destroy(collision.gameObject);
        }
    }

    public void Dealet()
    {
        deafetUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void New()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
