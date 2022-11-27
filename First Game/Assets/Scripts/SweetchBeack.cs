using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetchBeack : MonoBehaviour
{
    public GameObject BackGround;
    public GameObject MeinBeck;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            BackGround.SetActive(false);
            MeinBeck.SetActive(true);
        }
    }
}
