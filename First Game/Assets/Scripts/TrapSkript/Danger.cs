using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bulletEffect;
    private Player player;
    public int damage;

    [SerializeField] private AudioSource Hrust;
    [SerializeField] private AudioSource seapi;

    Vector2 currentPosition;
    bool moveingBack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        currentPosition = transform.position;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && moveingBack == false)
        {
            seapi.Play();
            FallPlatform();
        }
    }

    void OnCollisionEnter2D(Collision2D ñollision)
    {
        if (ñollision.gameObject.tag == "Player" )
        {          
            TakeDamage();
        }
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
        Invoke("BackPlatform", 2f);
    }

    void BackPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        moveingBack = true;
    }

    private void Update()
    {
        if (moveingBack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPosition, 20f * Time.deltaTime);
        }

        if (transform.position.y == currentPosition.y)
        {
            moveingBack = false;
        }
    }

    public void TakeDamage()
    {
        player.health -= damage;
        Hrust.Play();
        Instantiate(bulletEffect, player.transform.position, Quaternion.identity);
    }

}
