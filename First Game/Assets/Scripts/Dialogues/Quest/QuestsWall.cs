using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsWall : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource Miss;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" && other.gameObject.GetComponent<UIitem>().itemID == 3)
        {
            Destroy(other.gameObject);
            anim.SetTrigger("isTreggered");
            Miss.Play();
        }
    }
    
}
