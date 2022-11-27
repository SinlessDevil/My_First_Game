using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlush : MonoBehaviour
{
    private Player player;
    public int damage;
    public float destroyTime;
    public GameObject bulletEffect;
    public GameObject sound;

    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);

        Invoke("DestroyAmmo", destroyTime);
        player = FindObjectOfType<Player>();
    }

    void OnCollisionEnter2D(Collision2D ñol)
    {
        if (ñol.gameObject.tag == "Player")
        {
            TakeDamage();
            Shake.instance.StartShake(.1f, .1f);
            Instantiate(sound, transform.position, Quaternion.identity);
            Instantiate(bulletEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }

        if (ñol.gameObject.tag == "Platform")
        {
            Instantiate(sound, transform.position, Quaternion.identity);
            Instantiate(bulletEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }

    }

    public void TakeDamage()
    {
        player.health -= damage;
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
