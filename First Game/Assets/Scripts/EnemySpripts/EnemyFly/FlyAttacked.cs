using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAttacked : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public GameObject deathEffect;
    public int damage;
    private Player player;
    private Animator anim;
    private bool _isPlayerNear;

    [SerializeField] private AudioSource attackfly;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        _isPlayerNear = false;
    }

    private void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (timeBtwAttack <= 0)
            {

                anim.SetTrigger("FlyAttc");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
            _isPlayerNear = true; // отмечаем, что игрок рядом
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNear = false; // отмечаем, что игрок НЕ рядом  
        }
    }

    public void OnEnemyAttack()
    {
        if (_isPlayerNear)
        {
            Instantiate(deathEffect, player.transform.position, Quaternion.identity);
            player.health -= damage;
            attackfly.Play();
        }
        timeBtwAttack = startTimeBtwAttack;
    }

}
