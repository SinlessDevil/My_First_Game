using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFly : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    public GameObject bullet;
    public GameObject bulletParent;
    public GameObject Rangebullet;

    private Transform player;
    private Animator anim;
    private float nextFireTime;
    private Enemy1 Enrgy;
    [SerializeField] private AudioSource flystep;
    [SerializeField] private AudioSource Bleee;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        flystep = GetComponent<AudioSource>();
        Enrgy = GetComponent<Enemy1>();
    }


    void Update()
    {
        if (Enrgy.health < 15)
        {
            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            }
            else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
            {
                Bleee.Play();
                anim.SetTrigger("RangeFly");
            }
            Flip();
        }
        else
        {
            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            }
            else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
            {
                Bleee.Play();
                anim.SetTrigger("AttackFly");
            }
            Flip();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > player.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;
    }

    public void FlyShooting()
    {
        Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
        nextFireTime = Time.time + fireRate;
    }

    public void RangeFlyShootig()
    {
        Instantiate(Rangebullet, bulletParent.transform.position, Quaternion.identity);
        nextFireTime = Time.time + fireRate;
    }

    private void Footstep()
    {
        flystep.Play();
    }
}
