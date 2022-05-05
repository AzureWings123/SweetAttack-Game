using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numOfEnemies;
    public GameObject[] enemyTypes;
    public float spawnInterval;
}
public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;
    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0 && !canSpawn && currentWaveNumber+1 != waves.Length)
        {
            currentWaveNumber++;
            canSpawn = true;
        }
        if (totalEnemies.Length == 0 && currentWaveNumber + 1 == waves.Length)
        {
            Debug.Log("GameFinished"); //You won; UI to go to next level goes here
        }
    }
    void SpawnWave()
    {
        int startingNumEnemies = currentWave.numOfEnemies;
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.enemyTypes[Random.Range(0, currentWave.enemyTypes.Length)]; //choose 
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            if (currentWave.enemyTypes.Length > 1 && currentWave.numOfEnemies < startingNumEnemies) // so you don't face off against too many of the same enemy in multitype waves
            {
                GameObject lastSpawned = randomEnemy;
                do
                {
                    randomEnemy = currentWave.enemyTypes[Random.Range(0, currentWave.enemyTypes.Length)];
                } while (lastSpawned == randomEnemy);

            }
            currentWave.numOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.numOfEnemies == 0)
            {
                canSpawn = false;
            }
        }
    }
}
