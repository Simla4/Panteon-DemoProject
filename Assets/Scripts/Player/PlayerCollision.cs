using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AnimationController animationController;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            gameObject.transform.position = Vector3.zero;
        }

        if(other.gameObject.CompareTag("Finish"))
        {
            InputManager.Instance.isSwerveMechanismActive = false;
            animationController.Idle();
        }
    }
}
