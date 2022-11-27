using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int health;
    public int MaxHitpoints = 5;

    public HealthBarBeheveor Healthbar;
    public GameObject Money;
    public GameObject Blood;
    public GameObject Dead;
    public GameObject soundDead;

    void Start()
    {    
        health = MaxHitpoints;
        Healthbar.SetHealth(health, MaxHitpoints);
    }

    public void TakeDamage(int damage)
    {
        health -= damage ;
        Healthbar.SetHealth(health, MaxHitpoints);
        Instantiate(Blood, transform.position, Quaternion.identity);

        if (health <= 0)
        {
            Instantiate(Money, transform.position, Quaternion.identity);
            Instantiate(Dead, transform.position, Quaternion.identity);
            Instantiate(soundDead, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
