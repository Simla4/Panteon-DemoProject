using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Run()
    {
        animator.SetTrigger("Run");
    }

    public void Idle()
    {
        animator.SetTrigger("Idle");
    }
}
