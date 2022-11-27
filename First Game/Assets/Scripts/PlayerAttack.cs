using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;
    bool isAttacking = false;

    [SerializeField] private AudioSource missAttack;
    [SerializeField] private AudioSource attackMob;

    
    private void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
            anim.SetTrigger("attack");
            Invoke("ResetAttack", .5f);
        }
    }

  

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);


        if (enemies.Length == 0)
            missAttack.Play();
        else
            attackMob.Play();
     
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy1>().TakeDamage(damage);         
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

   void ResetAttack()
   {
        isAttacking = false;
   }


 
}
