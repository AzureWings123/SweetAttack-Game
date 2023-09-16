using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyAndAmount
{
    public GameObject enemy;
    public int amount;

    public void Spawn(Transform[] spawnPoints)
    {
        for (int i = 0; i < amount; i++)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, randomPoint.position, Quaternion.identity);
        }
    }
}
