using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour
{
    
    public static void ShowEndGame()
    {
        Time.timeScale = 0;
        ReferenceLib.Instance.endGamePanel.SetActive(true);
    }

    public static void GameOver()
    {
        Application.Quit();
    }
}
