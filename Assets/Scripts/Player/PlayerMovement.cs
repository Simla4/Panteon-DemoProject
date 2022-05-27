using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 7;

    [SerializeField] private float sidewaysMovementSensivity;
    [SerializeField] private float sidewaysMovementLerpSensivity;
    [SerializeField] private float sidewaysLimitPos;
 
    private Vector3 inputDrag;
    private Vector2 prevMousePos;
    private float sideMovementTarget;

    // Update is called once per frame
    void Update()
    {
        InputManager.Instance.IsGameStart();
        
        if(InputManager.Instance.isGameStart)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void MoveSideways()
    {
        sideMovementTarget += inputDrag.x * sidewaysMovementSensivity;
        sideMovementTarget = Mathf.Clamp(sideMovementTarget, -sidewaysLimitPos, sidewaysLimitPos);
        var localPos = transform.localPosition;
        localPos.x = Mathf.Lerp(localPos.x, sideMovementTarget, Time.deltaTime * sidewaysMovementLerpSensivity);
        transform.localPosition = localPos;
    }
}
