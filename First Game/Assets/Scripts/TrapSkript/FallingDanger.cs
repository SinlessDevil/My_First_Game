using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDanger : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bulletEffect;
    public GameObject TrapEffect;
    private Player player;
    public int damage;

    public GameObject sound;
    public GameObject sound1;

    [SerializeField] private AudioSource Miss;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Miss.Play();
            rb.isKinematic = false;
        }
    }

    void OnCollisionEnter2D(Collision2D ñollision)
    {
        if (ñollision.gameObject.tag == "Player")
        {
            TakeDamage();
            Destroy(gameObject);
        }
 
        if (ñollision.gameObject.tag == "Platform")
        {
            Instantiate(TrapEffect,transform.position, Quaternion.identity);
            Instantiate(sound1, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

  

    public void TakeDamage()
    {
        player.health -= damage;
        Instantiate(bulletEffect, player.transform.position, Quaternion.identity);
        Instantiate(TrapEffect, transform.position, Quaternion.identity);
        Instantiate(sound, transform.position, Quaternion.identity);

    }
}
