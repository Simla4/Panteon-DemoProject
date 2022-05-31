using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    [SerializeField] private float targetVelocity = 10;
    [SerializeField] private int numberOfRays = 17;
    [SerializeField] private float angle = 90;

    [SerializeField] private float rayRange = 2;

    // Update is called once per frame
    void Update()
    {
        if(InputManager.Instance.isGameStart && InputManager.Instance.isSwerveMechanismActive)
        {
            MoveOpponent();
            AvoidObstacle();
            AnimationController.Instance.ChangeAnimation(gameObject, AnimationType.Run);
        }
    }

    private void MoveOpponent()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnDrawGizmos() 
    {
        for (int i = 0; i < numberOfRays; i++)
        {
            var rotation = this.transform.rotation;
            var rotationMod =  Quaternion.AngleAxis((i / (float)numberOfRays) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMod * Vector3.forward * 1.5f;

            Gizmos.color = Color.red;
            Gizmos.DrawRay(this.transform.position, direction);
        }
    }

    private void AvoidObstacle()
    {
        var deltaPos = Vector3.zero;

        for (int i = 0; i < numberOfRays; i++)
        {
            var rotation = this.transform.rotation;
            var rotationMod =  Quaternion.AngleAxis((i / (float)numberOfRays) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMod * Vector3.forward;
            var ray = new Ray(this.transform.position, direction);

            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, rayRange))
            {
                deltaPos -= (1.0f / numberOfRays) * targetVelocity * direction;
            }
            else
            {
                deltaPos += (1.0f / numberOfRays) * targetVelocity * direction;
            }
        }

        this.transform.position += deltaPos * Time.deltaTime;
    }
}
