using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    public float offset;
    public GameObject bullet;
    public GameObject Woflbullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public int currentAmmo = 15;
    public int allAmmo = 0;
    public int fullAmmo = 45;

    [SerializeField]
    private Text ammoCount;
    [SerializeField] private AudioSource BlastSounds;
    [SerializeField] private AudioSource ReloadSound;
    public GameObject bullett = null;
    public Bullet lav = null;

    void Start()
    {
        lav = bullett.GetComponent<Bullet>();
    }

    void Update()
  {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0) && currentAmmo > 0)
            {   
                if(lav.damage == 1)
                {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                BlastSounds.Play();
                timeBtwShots = startTimeBtwShots;
                currentAmmo -= 1;
                }
                else if (lav.damage > 1)
                {
                Instantiate(Woflbullet, shotPoint.position, transform.rotation);
                BlastSounds.Play();
                timeBtwShots = startTimeBtwShots;
                currentAmmo -= 1;
                }


            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        ammoCount.text = currentAmmo + " / " + allAmmo;

        if(Input.GetKeyDown(KeyCode.R) && allAmmo > 0)
        {
            Reload();
            ReloadSound.Play();
        }
  }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BlasterClip>())
        {
            allAmmo += 10;
            Destroy(collision.gameObject);
        }
       
    }

    public void Reload()
    {
        int reason = 15 - currentAmmo;
        if (allAmmo >= reason)
        {
            allAmmo = allAmmo - reason;
            currentAmmo = 15;
        }
        else
        {
            currentAmmo = currentAmmo + allAmmo;
            allAmmo = 0;
        }
     

    }
}