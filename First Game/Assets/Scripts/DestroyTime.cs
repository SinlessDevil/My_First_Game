using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    public float destroyTime;

    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
