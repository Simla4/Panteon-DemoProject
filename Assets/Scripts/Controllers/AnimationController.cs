using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoSingleton<AnimationController>
{
    //[SerializeField] private Animator animator;

    public void ChangeAnimation(GameObject unit, AnimationType animationType)
    {
        var animator = unit.GetComponentInChildren<Animator>();

        animator.SetTrigger(animationType.ToString());
    }
}

public enum AnimationType
{
    Run,
    Idle
}
