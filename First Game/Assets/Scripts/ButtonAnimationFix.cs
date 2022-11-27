using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ButtonAnimationFix : MonoBehaviour
{
    public void FixAnimation()
    {
        Animator animator = GetComponent<Animator>();
        animator.CrossFade("Normal", 0f);
        animator.Update(0f);
    }
}
