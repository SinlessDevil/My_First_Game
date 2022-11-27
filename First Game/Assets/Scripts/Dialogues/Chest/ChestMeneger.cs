using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMeneger : MonoBehaviour
{
    public Animator ChestButton;
    public Animator Chest;

    [SerializeField] private AudioSource Open;

    private void Start()
    {

    }

    public void Button—hest(Chest herst)
    {
        ChestButton.SetBool("ChestOpen", false);
        Chest.SetBool("Chest", true);
        Open.Play();
    }
}
