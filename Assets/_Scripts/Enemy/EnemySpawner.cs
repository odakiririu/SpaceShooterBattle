using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Ins;
    private void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
            DontDestroyOnLoad(this);
        }
        else if (Ins)
        {
            Destroy(this);
        }
    }
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject parentObj;
    public float maxSpawneRateInSeconds = 4.5f;
    void SpawnEnemy()
    {
        // get postion top screen
        Vector2 minScreen = ScreenSize.Ins.minScreen;
        Vector2 maxScreen = ScreenSize.Ins.maxScreen;    

        GameObject anEnemy = (GameObject)Instantiate(prefabEnemy);
        anEnemy.transform.position = new Vector2(Random.Range(minScreen.x, maxScreen.x), maxScreen.y);
        anEnemy.transform.parent = parentObj.transform;
        ScheduleNextEnemySpawn();
    }
    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;
        if(maxSpawneRateInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawneRateInSeconds);
        }
        else
        {
            spawnInSeconds = 1f;
        }
        Invoke("SpawnEnemy",spawnInSeconds);
    }
    // function to increase the dificuly of the game;
    void IncreaseSpawnRate()
    {
        if(maxSpawneRateInSeconds > 1f)
        {
            maxSpawneRateInSeconds--;
        }
        if(maxSpawneRateInSeconds == 1)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
    public void StarSpawnEnemy()
    {
        Invoke("SpawnEnemy", maxSpawneRateInSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }
    public void StopSpawnEnemy()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
