using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMeneger : MonoBehaviour
{
    public Animator StartShopAnim;
    public Animator ShopBoxAnim;
    private Player player;
    private Money coin;
    public GameObject gun = null;
    public Gun val = null;
    public GameObject Cog;
    private PlayerAttack playerattack;
    public GameObject bullet = null;
    public Bullet lav = null;

    [SerializeField] private AudioSource MoneyBay;
    [SerializeField] private AudioSource Knopka;

    void Start()
    {
        player = FindObjectOfType<Player>();
        val = gun.GetComponent<Gun>();
        coin = FindObjectOfType<Money>();
        playerattack = FindObjectOfType<PlayerAttack>();
        lav = bullet.GetComponent<Bullet>();
    }

    public void StartShop(Shop shop)
    {
        ShopBoxAnim.SetBool("ShopBoxOpen", true);
        StartShopAnim.SetBool("StartShopOpen", false);

    }

    public void Bullet()
    {
        if(coin.money >= 50)
        {
            coin.money -= 50;
            val.allAmmo += 10;
            MoneyBay.Play();
        }
        else if(coin.money < 50)
        {
            coin.money -= 0;
            val.allAmmo += 0;
            Knopka.Play();
        }
    }

    public void Health()
    {
        if (coin.money >= 55)
        {
            coin.money -= 55;
            if (player.health == 10)
            {
                player.health += 0;
            }
            else if (player.health < 10)
            {
                player.health += 1;
            }
            MoneyBay.Play();
        }
        else if (coin.money < 55)
        {
            coin.money -= 0;
            player.health += 0;
            Knopka.Play();
        }

    }

    public void CogWellip()
    {
        if (coin.money >= 500)
        {
            coin.money -= 500;
            Cog.SetActive(true);
            MoneyBay.Play();
        }
        else if (coin.money < 500)
        {
            coin.money -= 0;
            Cog.SetActive(false);
            Knopka.Play();
        }
    }

    public void Sword()
    {
        if (coin.money >= 1500)
        {
            coin.money -= 1500;
            playerattack.damage += 1;
            MoneyBay.Play();
        }
        else if (coin.money < 1500)
        {
            coin.money -= 0;
            playerattack.damage += 0;
            Knopka.Play();
        }
    }

    public void Blaster()
    {
        if (coin.money >= 2000)
        {
            coin.money -= 2000;
            lav.damage += 1;
            MoneyBay.Play();
        }
        else if (coin.money < 2000)
        {
            coin.money -= 0;
            lav.damage += 0;
            Knopka.Play();
        }
    }


    public void EndShop()
    {
        ShopBoxAnim.SetBool("ShopBoxOpen", false);
        Knopka.Play();
    }
}
