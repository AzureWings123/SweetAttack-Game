using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class WaveSystem2 : MonoBehaviour
{
    public Wave2[] waves;
    public Transform[] spawnPoints;

    private Wave2 currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;
    private float spawnTimer;
    private EnemyAndAmount currentGroup;

    private int currentGroupIndex;

    private bool canSpawn = true;

    public GameObject GameOverCanvas;
    [SerializeField] private AudioClip WinSFX;

    private void Start()
    {
        canSpawn = true;
        currentWaveNumber = 0;
        currentGroupIndex = 0;
        spawnTimer = 0.0f;
        nextSpawnTime = 0.0f;
        currentGroup = new EnemyAndAmount();
    }

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(totalEnemies.Length == 0)
        {
            if(!canSpawn)
            {
                if(currentWaveNumber + 1 != waves.Length)
                {
                    currentWaveNumber++;
                    currentGroupIndex = 0;
                    canSpawn = true;
                }
                else
                {
                    GameOverCanvas.SetActive(true);
                    Time.timeScale = 0f;
                    int SP = PlayerPrefs.GetInt("SkillPoints");
                    SP += 10;
                    PlayerPrefs.SetInt("SkillPoints", SP);
                    SoundManagerScript.instance.PlaySound(WinSFX);
                } 
            }
            else
            {
                if(currentGroup.spawnNextInstantlayWhenAllDead)
                {
                    spawnTimer = nextSpawnTime;
                }
            }
        }

        SpawnWave();
    }

    void SpawnWave()
    {
        // int startingNumEnemies = currentWave.numOfEnemies;
        int numberOfGroups = currentWave.numberOfGroupsOfEnemies();
        spawnTimer += Time.deltaTime;

        if (canSpawn && nextSpawnTime <= spawnTimer)
        {
            currentGroup =  currentWave.enemies[currentGroupIndex];

            for (int i = 0; i < currentGroup.amount; i++)
            {
                GameObject enemy = currentGroup.enemy;
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(enemy, randomPoint.position, Quaternion.identity);
            }

            // GameObject randomEnemy = currentWave.enemyTypes[Random.Range(0, currentWave.enemyTypes.Length)]; //choose 
            // Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            // Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);

            // if (currentWave.enemyTypes.Length > 1 && currentWave.numOfEnemies < startingNumEnemies) // so you don't face off against too many of the same enemy in multitype waves
            // {
            //     GameObject lastSpawned = randomEnemy;
            //     do
            //     {
            //         randomEnemy = currentWave.enemyTypes[Random.Range(0, currentWave.enemyTypes.Length)];
            //     } while (lastSpawned == randomEnemy);

            // }

            // currentWave.numOfEnemies--;
            currentGroupIndex++;
            nextSpawnTime = currentGroup.delay;
            spawnTimer = 0.0f;

            // if(currentWave.numOfEnemies == 0)
            // {
            //     canSpawn = false;
            // }

            if(currentGroupIndex >= numberOfGroups)
            {
                canSpawn = false;
            }
        }
    }


}
