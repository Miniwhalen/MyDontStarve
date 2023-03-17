using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour
{

    private void Start()
    {
        GenerateRandomEnvironment();

    }

    private void Update()
    {
        GenerateEnemyTimer();
    }

    public void GenerateRandomEnvironment()
    {
        Vector2[,] centerPoints = new Vector2[40, 40];
        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                centerPoints[i, j] = new Vector2(-117 + 6 * i, -117 + 6 * j);
            }
        }
        foreach (var point in centerPoints)
        {
            int randomNum = Random.Range(0, 5);
            string name = "";
            switch (randomNum)
            {
                case 0:
                    name = "Wood";
                    break;
                case 1:
                    name = "Stone";
                    break;
                case 2:
                    name = "StickDown";
                    break;
                case 3:
                    name = "Cobble";
                    break;
                case 4:
                    name = "Berries";
                    break;
            }
            float offsetX = Random.Range(-1.5f, 1.5f);
            float offsetY = Random.Range(-1.5f, 1.5f);
            Instantiate(ResourceManager.interactableGOs[name], point + new Vector2(offsetX, offsetY), Quaternion.identity);

        }
    }

    public void GenerateRandomEnemy()
    {
        //int spawnCount = Random.Range(1, 4);
        int spawnCount = 1;
        for (int i = 0; i < spawnCount; i++)
        {
            float offsetX = Random.Range(-15f, 15f);
            float offsetY = Random.Range(-15f, 15f);
            Instantiate(ResourceManager.enemyGO, PlayerController.Instance.transform.position + new Vector3(offsetX, offsetY, 0), Quaternion.identity);

        }

    }

    private float geneTimer = 0;
    private float geneInterval = 60;
    private void GenerateEnemyTimer()
    {
        if (DayCycleController.cycleState != DayCycleController.CycleState.NIGHT)
        {
            geneTimer += Time.deltaTime;
            if (geneTimer > geneInterval)
            {
                GenerateRandomEnemy();
                geneTimer = 0;
            }
        }
    }

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
