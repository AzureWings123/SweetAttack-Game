using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Group
{
    public string groupName;
    public EnemyAndAmount[] enemies;
    public float delay;
    public bool spawnNextInstantlayWhenAllDead = true;

    public int totalNumberOfEnemies()
    {
        int output = 0;
        foreach (EnemyAndAmount enemy in enemies)
        {
            output += enemy.amount;
        }
        return output;
    }

    public int totalNumberOfUniqueEnemies()
    {
        return enemies.Length;
    }
}
