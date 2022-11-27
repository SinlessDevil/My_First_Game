using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uichest : MonoBehaviour
{
    public GameObject key;
    public GameObject Gold;

    public void Loot()
    {
        key.SetActive(true);
        Gold.SetActive(true);
    }
}
