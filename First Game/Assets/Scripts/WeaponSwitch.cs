using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject gun;
    public GameObject sword;

    [SerializeField] private AudioSource GunSwitchSound;
    [SerializeField] private AudioSource SwordSwichSound;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gun.activeInHierarchy == true)
            {
                gun.SetActive(false);
                sword.SetActive(true);
                GunSwitchSound.Play();
            }
            else if (sword.activeInHierarchy == true)
            {
                sword.SetActive(false);
                gun.SetActive(true);
                SwordSwichSound.Play();
            }
        }
    }

}
