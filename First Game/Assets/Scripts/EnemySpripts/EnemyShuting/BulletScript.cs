using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Player player;
    public int damage;
    public float destroyTime;
    public GameObject bulletEffect;
    public GameObject sound;

    

    void Start()
    {
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
