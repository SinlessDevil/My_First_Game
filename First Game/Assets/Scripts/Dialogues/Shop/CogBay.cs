using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogBay : MonoBehaviour
{
    public GameObject Cog;
    [SerializeField] private AudioSource MoneyBay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cogbay()
    {
        MoneyBay.Play();
        Instantiate(Cog, transform.position, Quaternion.identity);
    }
}
