using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurrent : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;

    Vector2 Direction;

    public GameObject Gun;
    public GameObject Bullet;
    public GameObject Bullett;
    public Transform ShootPoint;

    public float FireRate;
    float nextTimeToFire = 0;
    public float Force;
    private Enemy1 Enrgy;
    private Player player;
    private Animator animator;
    public GameObject sound;

    [SerializeField] private AudioSource BoomSounds;
    [SerializeField] private AudioSource BoommSounds;


    void Start()
    {
        player = FindObjectOfType<Player>();
        Enrgy = GetComponent<Enemy1>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
        }

        if (Detected)
        {
            Gun.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
        if (Enrgy.health < 15)
        {
            GameObject BulletIns = Instantiate(Bullett, ShootPoint.position, Quaternion.identity);
            BoommSounds.Play();
            BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
            animator.SetTrigger("Engry");
            Instantiate(sound, transform.position, Quaternion.identity);

        }
        else
        {
            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            BoomSounds.Play();
            BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
