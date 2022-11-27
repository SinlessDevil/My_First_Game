using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrentScpit : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;

    Vector2 Direction;

    public GameObject Gun;
    public GameObject Bullet;
    public Transform ShootPoint;

    public float FireRate;
    float nextTimeToFire = 0;
    public float Force;

    [SerializeField] private AudioSource BoomSounds;


    void Start()
    {
        
    }

    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
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
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
       GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        BoomSounds.Play();
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
