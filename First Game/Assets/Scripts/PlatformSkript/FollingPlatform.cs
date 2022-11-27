using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private AudioSource Miss;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Miss.Play();
            Invoke("FallPlatform", .1f);
            Shake.instance.StartShake(.1f, .1f);
            Destroy(gameObject, 2f);
        }
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
    }
}
