using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private UnityEvent OnLevelFail;
    [SerializeField] private UnityEvent OnLevelWin;

    public void LevelFail()
    {
        OnLevelFail?.Invoke();
    }

    public void LevelWin()
    {
        OnLevelWin?.Invoke();
    }
}
