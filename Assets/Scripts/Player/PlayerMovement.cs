using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform playerRoot;

    [SerializeField] float speed = 7;

    [SerializeField] private float sidewaysMovementSensivity;
    [SerializeField] private float sidewaysMovementLerpSensivity;
    [SerializeField] private float sidewaysLimitPos;
 
    private float sideMovementTarget;

    // Update is called once per frame
    void Update()
    {

        if(InputManager.Instance.isGameStart && InputManager.Instance.isSwerveMechanismActive)
        {
            InputManager.Instance.SwerveInput();
            MoveSideways();
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        playerRoot.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void MoveSideways()
    {
        sideMovementTarget += InputManager.Instance.inputDrag.x * sidewaysMovementSensivity;
        sideMovementTarget = Mathf.Clamp(sideMovementTarget, -sidewaysLimitPos, sidewaysLimitPos);
        var localPos = playerRoot.localPosition;
        localPos.x = Mathf.Lerp(localPos.x, sideMovementTarget, Time.deltaTime * sidewaysMovementLerpSensivity);
        playerRoot.localPosition = localPos;
    }
}
