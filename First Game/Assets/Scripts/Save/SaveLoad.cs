using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public Transform PlayerTransform;
    float playerPosX = -4;
    float playerPosY = 2;
    private Player player;

    private VolumeVile vile;
    private Money coin;
    private PlayerAttack playerattack;
    public GameObject gun = null;
    public Gun val = null;

    public GameObject bullet = null;
    public Bullet pulya = null;


    void Start()
    {

        val = gun.GetComponent<Gun>();
        player = FindObjectOfType<Player>();
        vile = FindObjectOfType<VolumeVile>();
        coin = FindObjectOfType<Money>();
        playerattack = FindObjectOfType<PlayerAttack>();
        pulya = bullet.GetComponent<Bullet>();
        LoadingData();
    }

    void Update()
    {
        playerPosX = (float)PlayerTransform.position.x;
        playerPosY = (float)PlayerTransform.position.y;
    }

    public void SavingData()
    {
        PlayerPrefs.SetFloat("PosXX", playerPosX);
        PlayerPrefs.SetFloat("PosYY", playerPosY);
        PlayerPrefs.SetInt("Healthh", player.health);

        PlayerPrefs.SetInt("CurrenAmmoo", val.currentAmmo);
        PlayerPrefs.SetInt("AllAmmoo", val.allAmmo);
        PlayerPrefs.SetFloat("MusicVolume", vile.musicVolume);
        PlayerPrefs.SetInt("MoneyCoin", coin.money);
        PlayerPrefs.SetInt("Attackk", playerattack.damage);
        PlayerPrefs.SetInt("Bulleett", pulya.damage);
        OnApplicationQuit();
    }

    public void LoadingData()
    {
        if(PlayerPrefs.HasKey("PosXX") || PlayerPrefs.HasKey("PosYY") || PlayerPrefs.HasKey("Healthh") || PlayerPrefs.HasKey("CurrenAmmoo") || PlayerPrefs.HasKey("AllAmmoo") || PlayerPrefs.HasKey("MusicVolume") || PlayerPrefs.HasKey("MoneyCoin") || PlayerPrefs.HasKey("Attackk") || PlayerPrefs.HasKey("Bulleett"))
        {
            playerPosX = PlayerPrefs.GetFloat("PosXX");
            playerPosY = PlayerPrefs.GetFloat("PosYY");
            player.health = PlayerPrefs.GetInt("Healthh");

            val.currentAmmo = PlayerPrefs.GetInt("CurrenAmmoo");
            val.allAmmo = PlayerPrefs.GetInt("AllAmmoo");
            vile.musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            coin.money = PlayerPrefs.GetInt("MoneyCoin");
            playerattack.damage = PlayerPrefs.GetInt("Attackk");
            pulya.damage = PlayerPrefs.GetInt("Bulleett");
            PlayerTransform.position = (new Vector2(playerPosX, playerPosY));
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerTransform.position = (new Vector2(-4, 2));
        player.health = 10;
        coin.money = 0;
        val.currentAmmo = 0;
        val.allAmmo = 0;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

}
