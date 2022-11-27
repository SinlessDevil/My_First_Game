using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimator : MonoBehaviour
{
    public Animator ChestButton;

    public Animator Chest;

    public void OnTriggerEnter2D(Collider2D other)
    {
        ChestButton.SetBool("ChestOpen", true);
        Chest.SetBool("Chest", false);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        ChestButton.SetBool("ChestOpen", false);
        Chest.SetBool("Chest", false);
    }
}
