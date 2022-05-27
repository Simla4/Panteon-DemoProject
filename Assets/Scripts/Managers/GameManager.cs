using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoSingleton<GameManager>
{
    public void LevelFail()
    {
        LevelManager.Instance.LoadLevel();
        Time.timeScale = 1;
    }

    public void LevelWin()
    {
        LevelManager.Instance.LoadLevel();
        Time.timeScale = 1;
    } 
}
