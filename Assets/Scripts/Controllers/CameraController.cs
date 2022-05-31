using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoSingleton<CameraController>
{
    [SerializeField] private CinemachineVirtualCamera vcam1;

    public void ChangeTheCamera()
    {
        vcam1.Priority -= 2;
    }
}
