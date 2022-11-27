using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int money ;

    [SerializeField]
    private Text moneyCount;

    public GameObject coin;

    void Start()
    {
        
    }

    void Update()
    {
        moneyCount.text = money + "/";
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MoneyClip>())
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            money += 10;
            Destroy(collision.gameObject);
        }

        if (collision.GetComponent<BagGoldClip>())
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            money += 300;
            Destroy(collision.gameObject);
        }
    }
}
