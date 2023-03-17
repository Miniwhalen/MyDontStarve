using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelMainController : MonoBehaviour
{
    

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
