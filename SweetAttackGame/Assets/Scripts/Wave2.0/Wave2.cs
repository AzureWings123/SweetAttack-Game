using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Wave2
{
    public string waveName;
    public float spawnInterval;

    public EnemyAndAmount[] enemies;

    public int totalNumberOfEnemies()
    {
        int output = 0;
        foreach (EnemyAndAmount enemy in enemies)
        {
            output += enemy.amount;
        }
        return output;
    }

    public int numberOfGroupsOfEnemies()
    {
        return enemies.Length;
    }
}
