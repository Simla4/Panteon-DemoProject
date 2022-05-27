using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoSingleton<InputManager>
{

    private Vector3 inputDrag;
    private Vector2 prevMousePos;
    private float sideMovementTarget;

    public bool isGameStart = false;

    [SerializeField] private UnityEvent OnGameStart;

     private Vector2 mousePositionCM
    {
        get
        {
            Vector2 pixels = Input.mousePosition;
            var inches = pixels / Screen.dpi;
            var centimeters = inches * 2.54f;

            return centimeters;
        }
    }

    public void GetInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            prevMousePos = mousePositionCM;
        }
        else if(Input.GetMouseButton(0))
        {
            var distance = mousePositionCM - prevMousePos;
            inputDrag = distance;
            prevMousePos = mousePositionCM;
        }
        else
        {
            inputDrag = Vector2.zero;
        }
    }

    public void IsGameStart()
    {
        if (Input.GetMouseButtonUp(0) && !isGameStart) //for tap to start
        {
            OnGameStart?.Invoke();
            isGameStart = true;
        }
    }
}
