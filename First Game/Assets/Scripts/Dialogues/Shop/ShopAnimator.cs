using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimator : MonoBehaviour
{
    public Animator StartShopAnim;

    public Animator ShopBoxAnim;

    public void OnTriggerEnter2D(Collider2D other)
    {
        StartShopAnim.SetBool("StartShopOpen", true);
        ShopBoxAnim.SetBool("ShopBoxOpen", false);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        StartShopAnim.SetBool("StartShopOpen", false);
        ShopBoxAnim.SetBool("ShopBoxOpen", false);
    }
}

