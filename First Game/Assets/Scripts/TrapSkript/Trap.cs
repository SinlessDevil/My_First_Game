using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Player player;
    public int damage;
    public GameObject bllood;

    [SerializeField] private AudioSource Blood;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void OnCollisionEnter2D(Collision2D ñollision)
    {
        if (ñollision.gameObject.tag == "Player")
        {
            TakeDamage();
            
        }
    }



    public void TakeDamage()
    {
        player.health -= damage;
        Instantiate(bllood, player.transform.position, Quaternion.identity);
        Blood.Play();
    }
}
