using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public Shop shop;

    public void TriggerShop()
    {
        FindObjectOfType<ShopMeneger>().StartShop(shop);
    }
}
