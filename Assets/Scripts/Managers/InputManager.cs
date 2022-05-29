using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoSingleton<InputManager>
{

    [HideInInspector] public Vector3 inputDrag;
    [HideInInspector] public Vector2 prevMousePos;

    public bool isGameStart = false;

    public bool isSwerveMechanismActive = true;

    [SerializeField] private UnityEvent OnGameStart;

    void Update()
    {
        IsGameStart();    
    }

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

    public void SwerveInput()
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
        else if(Input.GetMouseButtonUp(0))
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
